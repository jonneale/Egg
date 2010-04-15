using System;
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
		protected IRestClient RestClient;
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
			View.PlanSelected += SelectPlan;
			View.SupplierSelected += SelectSupplier;
			View.PaymentMethodSelected += SelectPaymentMethod;
		}

		public abstract void SelectPlan(Plan plan);

		public abstract void SelectSupplier(Supplier supplier);

		public abstract void SelectPaymentMethod(string paymentMethod);

		public virtual void Loaded()
		{
			EventHub.Register<RegionFoundEvent>(e =>
			                                    	{
														View.Region = e.Region;
			                                    		LoadDefaultSuppliersAndPlans(e.Region);
			                                    	});
		}

		public abstract void LoadDefaultSuppliersAndPlans(string region);

		protected void CallDispatcher(Action action)
		{
			Dispatcher.BeginInvoke(action);
		}
	}
}