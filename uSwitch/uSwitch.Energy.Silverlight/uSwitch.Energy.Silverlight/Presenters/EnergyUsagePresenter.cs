using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Threading;
using uSwitch.Energy.Silverlight.Core;
using uSwitch.Energy.Silverlight.Events;
using uSwitch.Energy.Silverlight.Model;
using uSwitch.Energy.Silverlight.Rest;
using uSwitch.Energy.Silverlight.Views;

namespace uSwitch.Energy.Silverlight.Presenters
{
	public abstract class EnergyUsagePresenter
	{
		protected readonly IEnergyUsageView View;
		protected readonly IRestClient RestClient;
		protected readonly Dispatcher Dispatcher;
		protected readonly IEventHub EventHub = Core.EventHub.GetCurrent();

		protected EnergyUsagePresenter(IEnergyUsageView view, Dispatcher dispatcher)
			: this(view, RestClientFactory.GetDefault(), dispatcher)
		{
		}

		protected EnergyUsagePresenter(IEnergyUsageView view, IRestClient restClient, Dispatcher dispatcher)
		{
			View = view;
			RestClient = restClient;
			Dispatcher = dispatcher;
			View.SupplierSelected += SelectSupplier;
			View.PaymentMethodSelected += SelectPaymentMethod;
		}

		public abstract void SelectSupplier(Supplier supplier);

		public abstract void SelectPaymentMethod(string paymentMethod);

        public void CalculateSpendOrUsage()
        {
            if (View.IsInKwh)
            {
                View.CalculatedUsageInKwh = GetUsageAmountForYear();
                View.CalculatedAnnualSpend = 0;
            } else
            {
                View.CalculatedAnnualSpend = GetSpendAmountForYear();
                View.CalculatedUsageInKwh = 0;
            }
        }

		public virtual void Loaded()
		{
			View.TimePeriods = TimePeriod.GetAll();
			View.SelectedTimePeriod = TimePeriod.OneMonth;

		    EventHub.Register<PreCompareEvent>(e => CalculateSpendOrUsage());

			EventHub.Register<RegionFoundEvent>(e =>
			                                    	{
														View.Region = e.Region;
			                                    		LoadDefaultSuppliersAndPlans(e.DefaultRegionInfo);
			                                    	});
		}

        public abstract void LoadDefaultSuppliersAndPlans(DefaultRegionInformation defaultRegionInfo);

		protected void CallDispatcher(Action action)
		{
			Dispatcher.BeginInvoke(action);
		}

		protected virtual double GetSpendAmountForYear()
		{
            double amount = double.Parse(Regex.Match(View.AmountText, @"\d.").Value);
            return TimePeriod.CalculateCostOverYear(View.SelectedTimePeriod, amount);
		}

        protected virtual double GetUsageAmountForYear()
        {
            double amount = double.Parse(Regex.Match(View.AmountText, @"\d.").Value);
            return TimePeriod.CalculateKwhOverYear(View.SelectedTimePeriod, amount);
        }

        protected void DeActivateSelectedSupplierEvent()
        {
            View.DeActivateSelectedSupplierEvent = true;
        }

        protected void ActivateSelectedSupplierEvent()
        {
            View.DeActivateSelectedSupplierEvent = false;
        }
	}
}