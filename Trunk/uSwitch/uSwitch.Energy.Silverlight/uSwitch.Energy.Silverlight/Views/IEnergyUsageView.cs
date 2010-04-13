using System;
using System.Collections.Generic;
using uSwitch.Energy.Silverlight.Model;

namespace uSwitch.Energy.Silverlight.Views
{
	public interface IEnergyUsageView
	{
		event Action<Supplier> SupplierSelected;

		event Action<Plan> PlanSelected;

		event EventHandler LoadDefaults;

		IEnumerable<Supplier> Suppliers
		{
			get; set;
		}

		IEnumerable<Plan> Plans
		{
			get;
			set;
		}

		Supplier SelectedSupplier
		{
			get;
			set;
		}

		Plan SelectedPlan
		{
			get; set;
		}
	}
}