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
        	View.HasGas = hasGas;
			EventHub.Publish(new HasGasChangedEvent { HasGas = hasGas});
        }

        public void Loaded()
        {
        	View.PaymentMethod = PaymentMethods.FixedMonthlyDirectDebit;
        	View.HasEconomy7 = false;

            Action<ComparisonReceivedEvent> eventCallBack = c => 
            {
                View.UsagePanelsVisible = false;
            };
            EventHub.Register(eventCallBack);

        	Action<ComparisonRefinedEvent> comparisonRefinedCallBack = ComparisonRefinedCallBack;
			EventHub.Register(comparisonRefinedCallBack);
        }

		private void ComparisonRefinedCallBack(ComparisonRefinedEvent @event)
		{
			
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
            EventHub.Publish(new PreCompareEvent());

            var compareEvent = new CompareEvent
                                   {
                                       ElectricityPlan = View.ElectricityUsageView.SelectedPlan,
                                       ElectricitySupplier = View.ElectricityUsageView.SelectedSupplier,
                                       GasPlan = View.GasUsageView.SelectedPlan,
                                       GasSupplier = View.GasUsageView.SelectedSupplier,
                                       ComparisonPaymentMethod = View.PaymentMethod,
									   HasGas = View.HasGas,
                                       ElectricityPaymentMethod = View.ElectricityUsageView.PaymentMethod,
                                       GasPaymentMethod = View.GasUsageView.PaymentMethod,
                                       Postcode = View.Postcode,
                                       IsEconomy7 = View.HasEconomy7
                                   };

            if (View.ElectricityUsageView.IsInKwh)
            {
                compareEvent.ElectricityAnnualConsumptionKwh = View.ElectricityUsageView.CalculatedUsageInKwh;
            } else
            {
                compareEvent.ElectricityAnnualSpend = View.ElectricityUsageView.CalculatedAnnualSpend;
            }

            if (View.GasUsageView.IsInKwh)
            {
                compareEvent.GasAnnualConsumptionKwh = View.GasUsageView.CalculatedUsageInKwh;
            }
            else
            {
                compareEvent.GasAnnualSpend = View.GasUsageView.CalculatedAnnualSpend;
            }

            EventHub.Publish(compareEvent);
        }

		protected void CallDispatcher(Action action)
		{
			Dispatcher.BeginInvoke(action);
		}
	}
}