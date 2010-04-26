using System;
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
		}

        public void Loaded()
        {
            Action<ComparisonReceivedEvent> eventCallBack = c => 
            {
                View.UsagePanelsVisible = false;
            };
            EventHub.Register(eventCallBack);

            Action<ResultSelected> resultSelectedEventCallBack = r =>
                                                                     {
                                                                         var query =
                                                                             new GetTariffInfoForPlan(r.SupplierName,
                                                                                                      r.PlanName,
                                                                                                      PaymentMethods.
                                                                                                          FixedMonthlyDirectDebit,
                                                                                                      Products.
                                                                                                          Electricity,
                                                                                                      View.Region
                                                                                 );

                                                                         query.Execute(RestClient, tariff => CallDispatcher(() =>
                                                                                                                           {
                                                                                                                               MessageBox.Show("Tariff information: " + tariff.StandingCharge);
                                                                                                                           }));
                                                                     };

            EventHub.Register(resultSelectedEventCallBack);
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