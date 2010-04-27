using System;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using uSwitch.Energy.Silverlight.Core;
using uSwitch.Energy.Silverlight.Events;
using uSwitch.Energy.Silverlight.Model;
using uSwitch.Energy.Silverlight.Queries;
using uSwitch.Energy.Silverlight.Rest;
using uSwitch.Energy.Silverlight.Views;

namespace uSwitch.Energy.Silverlight.Presenters
{
	public class ApplicationPresenter
	{
		protected IRestClient RestClient;
		protected readonly Dispatcher Dispatcher;
		protected readonly IEventHub EventHub = Core.EventHub.GetCurrent();
		public IApplicationView View { get; set; }

		public ApplicationPresenter(IApplicationView view, Dispatcher dispatcher)
		{
			View = view;
			RestClient = RestClientFactory.GetDefault();
			Dispatcher = dispatcher;
			view.FindRegionPressed += FindRegion;
		    View.Compare += Compare;
            View.HasGasChanged += HasGasChanged;
		}

        public void HasGasChanged(bool hasGas)
        {
            View.
        }

        public void Loaded()
        {
            Action<ComparisonReceivedEvent> eventCallBack = c => 
            {
                View.UsagePanelsVisible = false;
            };
            EventHub.Register(eventCallBack);

        	Action<ResultSelected> resultSelectedEventCallBack = ResultSelectedCallBack;
            EventHub.Register(resultSelectedEventCallBack);
        }

		private void ResultSelectedCallBack(ResultSelected resultSelected)
		{
			var queryElectricity = new GetTariffInfoForPlan(resultSelected.SupplierName, 
				resultSelected.PlanKey,
				PaymentMethods.FixedMonthlyDirectDebit,
				Products.Electricity,
				View.Region);

            var queryGas = new GetTariffInfoForPlan(resultSelected.SupplierName, 
				resultSelected.PlanKey,
				PaymentMethods.FixedMonthlyDirectDebit,
				Products.Electricity,
				View.Region);

		    var state = new Tariff[2];

			queryElectricity.Execute(RestClient, tariff => CallDispatcher(() =>
			{
                lock (state)
			    {
                    state[0] = tariff;
                    if (state[1] != null)
                    {
                        PublishTariffInformationFoundEvent(state);
                    }
			    }
			}));

            queryGas.Execute(RestClient, tariff => CallDispatcher(() =>
            {
                lock (state)
                {
                    state[1] = tariff;
                    if (state[0] != null)
                    {
                        PublishTariffInformationFoundEvent(state);
                    }
                }
            }));
		}

        private void PublishTariffInformationFoundEvent(object[] tariffStateObjects)
        {
            PublishTariffInformationFoundEvent((Tariff) tariffStateObjects[0], (Tariff) tariffStateObjects[1]);
        }

        private void PublishTariffInformationFoundEvent(Tariff electricity, Tariff gas)
        {
            EventHub.Publish(new TariffInformationFoundEvent { ElectricityTariff = electricity , GasTariff = gas});
        }

		public void FindRegion(string postcode)
		{
			var query = new GetRegionFromPostCodeQuery(postcode);
			query.Execute(RestClient, postcodeLookupResult => CallDispatcher(
				() =>
				{
					View.Region = postcodeLookupResult.RegionName;
				    var defaultRegion = new GetDefaultEnergyPlansForRegionQuery(postcodeLookupResult.RegionName);
                    defaultRegion.Execute(RestClient, regionDefaultsResult => CallDispatcher(() =>
                                                                         {
                                                                             EventHub.Publish(new RegionFoundEvent 
                                                                                 { 
                                                                                     Region = postcodeLookupResult.RegionName,
                                                                                     DefaultRegionInfo = regionDefaultsResult 
                                                                                 });

                                                                             if (!string.IsNullOrEmpty(View.Region))
                                                                             {
                                                                                 View.UsageFadeInStoryboard.Begin();
                                                                                 View.InitialQuestionsVisible = false;
                                                                             }
                                                                         }));
				}));
		    View.Postcode = postcode;
		}

        public void Compare()
        {
            var compareEvent = new CompareEvent
                                   {
                                       ElectricityPlan = View.ElectricityUsageView.SelectedPlan,
                                       ElectricitySupplier = View.ElectricityUsageView.SelectedSupplier,
                                       GasPlan = View.GasUsageView.SelectedPlan,
                                       GasSupplier = View.GasUsageView.SelectedSupplier,
                                       ComparisonPaymentMethod = PaymentMethods.FixedMonthlyDirectDebit,
                                       HasGas = true,
                                       ElectricityAnnualConsumptionKwh = View.ElectricityUsageView.UsageInKwh,
                                       GasAnnualConsumptionKwh = View.GasUsageView.UsageInKwh,
                                       ElectricityPaymentMethod = View.ElectricityUsageView.PaymentMethod,
                                       GasPaymentMethod = View.GasUsageView.PaymentMethod,
                                       Postcode = View.Postcode,
                                       IsEconomy7 = false
                                   };
            EventHub.Publish(compareEvent);
        }

		protected void CallDispatcher(Action action)
		{
			Dispatcher.BeginInvoke(action);
		}
	}
}