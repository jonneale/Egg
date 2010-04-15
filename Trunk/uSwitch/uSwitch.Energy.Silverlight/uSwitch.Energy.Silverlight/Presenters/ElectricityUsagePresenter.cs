using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Threading;
using uSwitch.Energy.Silverlight.Model;
using uSwitch.Energy.Silverlight.Queries;
using uSwitch.Energy.Silverlight.Rest;
using uSwitch.Energy.Silverlight.Views;

namespace uSwitch.Energy.Silverlight.Presenters
{
	public class ElectricityUsagePresenter : EnergyUsagePresenter
	{
		public ElectricityUsagePresenter(IEnergyUsageView view, Dispatcher dispatcher) : base(view, dispatcher)
		{
		}

		public ElectricityUsagePresenter(IEnergyUsageView view, IRestClient restClient, Dispatcher dispatcher)
			: base(view, restClient, dispatcher)
		{

		}

		public override void LoadDefaultSuppliersAndPlans(string region)
		{
			var query = new AllSuppliersForProductAndRegionQuery("electricity", region);
			query.Execute(RestClient, suppliers => CallDispatcher(() =>
			{
				View.Suppliers = suppliers;
			    View.SelectedSupplier = suppliers.First();
			}));
		}

		public override void SelectSupplier(Supplier supplier)
		{
			var query = new PlansForSupplierQuery(supplier, View.PaymentMethod, "electricity", View.Region);

			Action<IEnumerable<Plan>> callBack = plans => CallDispatcher(() =>
			                                                             	{
			                                                             		View.Plans = plans;
																				View.SelectedPlan = plans.First();
			                                                             	});
			query.Execute(RestClient, callBack);
		}

		public override void SelectPaymentMethod(string paymentMethod)
		{
			var query = new PlansForSupplierQuery(View.SelectedSupplier, paymentMethod, "electricity", View.Region);
			query.Execute(RestClient, plans => CallDispatcher(() =>
			{
				View.Plans = plans;
				View.SelectedPlan = plans.First();
			}));
		}

		public override void SelectPlan(Plan plan)
		{
			
		}
	}
}