using System;
using System.Collections.Generic;
using uSwitch.Energy.Silverlight.Model;

namespace uSwitch.Energy.Silverlight.Views
{
	public interface IEnergyUsageView
	{
		event Action<Supplier> SupplierSelected;

		event Action<Plan> PlanSelected;

		event Action<string> PaymentMethodSelected;

		bool HasGas
		{
			get; set;
		}

		string Region
		{
			get; set;
		}

		string PaymentMethod
		{
			get; set;
		}

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

        string RegionDefaultSupplierName
        {
            get; set;
        }

        string RegionDefaultPlanName
        {
            get;
            set;
        }

		string Product
		{
			get; set;
		}

		Plan SelectedPlan
		{
			get; set;
		}

	    double UsageInKwh
	    { 
            get; set;
	    }
	}
}