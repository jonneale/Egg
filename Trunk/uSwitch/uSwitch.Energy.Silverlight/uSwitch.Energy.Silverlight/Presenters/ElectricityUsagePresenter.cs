using uSwitch.Energy.Silverlight.Model;
using uSwitch.Energy.Silverlight.Queries;
using uSwitch.Energy.Silverlight.Rest;
using uSwitch.Energy.Silverlight.Views;

namespace uSwitch.Energy.Silverlight.Presenters
{
	public class ElectricityUsagePresenter : EnergyUsagePresenter
	{
		public ElectricityUsagePresenter(IEnergyUsageView view) : base(view)
		{
		}

		public ElectricityUsagePresenter(IEnergyUsageView view, IRestClient restClient) : base(view, restClient)
		{

		}

		public override void SelectPlan(Plan plan)
		{
			base.SelectPlan(plan);
		}

		public override void SelectSupplier(Supplier supplier)
		{
			base.SelectSupplier(supplier);

			var query = new PlansForSupplierQuery(supplier);
			//var plans = query.Execute(RestClient);
		}
	}
}