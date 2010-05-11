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

        public void SetDefaultRegionInfo(DefaultRegionInformation regionInfo)
        {
            View.RegionDefaultSupplierName = regionInfo.DefaultElectricitySupplier;
            View.RegionDefaultPlanName = regionInfo.DefaultElectricityPlan;
        }

		public override void LoadDefaultSuppliersAndPlans(DefaultRegionInformation defaultRegionInfo)
		{
		    SetDefaultRegionInfo(defaultRegionInfo);

			var query = new AllSuppliersForProductAndRegionQuery("electricity", defaultRegionInfo.Name);
			query.Execute(RestClient, suppliers => CallDispatcher(() =>
			{
                DeActivateSelectedSupplierEvent();
				View.Suppliers = suppliers;
                ActivateSelectedSupplierEvent();
                View.SelectedSupplier = suppliers.Single(s => s.Name.Equals(View.RegionDefaultSupplierName));
			}));
		}

		public override void SelectSupplier(Supplier supplier)
		{
			var query = new PlansForSupplierQuery(supplier, View.PaymentMethod, "electricity", View.Region);

			Action<IEnumerable<Plan>> callBack = plans => CallDispatcher(() =>
			                                                             	{
			                                                             	    Plan defaultPlanName =
			                                                             	        plans.SingleOrDefault(
			                                                             	            p =>
			                                                             	            p.Name.Equals(View.RegionDefaultPlanName)) ??
			                                                             	        plans.First();

			                                                             		View.Plans = plans;
                                                                                View.SelectedPlan = defaultPlanName;
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
	}
}