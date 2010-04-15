using System;
using System.Collections.Generic;
using System.Windows.Threading;
using uSwitch.Energy.Silverlight.Model;
using uSwitch.Energy.Silverlight.Queries;
using uSwitch.Energy.Silverlight.Rest;
using uSwitch.Energy.Silverlight.Views;
using System.Linq;

namespace uSwitch.Energy.Silverlight.Presenters
{
	public class GasUsagePresenter : EnergyUsagePresenter
	{
		public GasUsagePresenter(IEnergyUsageView view, Dispatcher dispatcher) : base(view, dispatcher)
		{
		}

		public GasUsagePresenter(IEnergyUsageView view, IRestClient restClient, Dispatcher dispatcher)
			: base(view, restClient, dispatcher)
		{

		}

		public override void LoadDefaultSuppliersAndPlans(string region)
		{
			var query = new AllSuppliersForProductAndRegionQuery("gas", region);
			query.Execute(RestClient, suppliers => CallDispatcher(() =>
			{
				View.Suppliers = suppliers;
				View.SelectedSupplier = suppliers.First();
			}));
		}

		public override void SelectPaymentMethod(string paymentMethod)
		{
			var query = new PlansForSupplierQuery(View.SelectedSupplier, paymentMethod, "gas", View.Region);
			query.Execute(RestClient, plans => CallDispatcher(() =>
			{
				View.Plans = plans;
				View.SelectedPlan = plans.First();
			}));
		}

		public override void SelectPlan(Plan plan)
		{
			
		}

		public override void SelectSupplier(Supplier supplier)
		{
			var query = new PlansForSupplierQuery(supplier, View.PaymentMethod, "gas", View.Region);

			Action<IEnumerable<Plan>> callBack = plans => CallDispatcher(() =>
			{
				View.Plans = plans;
				View.SelectedPlan = plans.First();
			});
			query.Execute(RestClient, callBack);
		}
	}
}