using uSwitch.Energy.Silverlight.Model;
using uSwitch.Energy.Silverlight.Rest;
using uSwitch.Energy.Silverlight.Views;

namespace uSwitch.Energy.Silverlight.Presenters
{
	public class EnergyUsagePresenter
	{
		protected readonly IEnergyUsageView View;
		protected IRestClient RestClient;

		public EnergyUsagePresenter(IEnergyUsageView view) : this(view, RestClientFactory.GetDefault())
		{
		}

		public EnergyUsagePresenter(IEnergyUsageView view, IRestClient restClient)
		{
			View = view;
			RestClient = restClient;
			View.LoadDefaults += (sender, args) => LoadDefaultUI();
			View.PlanSelected += SelectPlan;
			view.SupplierSelected += SelectSupplier;
		}

		public void LoadDefaultUI()
		{
			View.Suppliers = new[]
			                 	{
			                 		new Supplier {Name = "Power gen"},
									new Supplier {Name = "British gas"},
			                 		new Supplier {Name = "E.on"}
			                 	};
			View.Plans = new[]
			             	{
			             		new Plan {Name = "Best plan 1"},
								new Plan {Name = "Another plan"},
								new Plan {Name = "Cheap plan"}
			             	};
		}

		public virtual void SelectPlan(Plan plan)
		{
		}

		public virtual void SelectSupplier(Supplier supplier)
		{
		}
	}
}