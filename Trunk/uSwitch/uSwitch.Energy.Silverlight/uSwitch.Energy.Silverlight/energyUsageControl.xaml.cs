using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using uSwitch.Energy.Silverlight.Model;
using uSwitch.Energy.Silverlight.Presenters;
using uSwitch.Energy.Silverlight.Views;

namespace uSwitch.Energy.Silverlight
{
	public partial class EnergyUsageControl : UserControl, IEnergyUsageView
	{
		private IEnumerable<Supplier> _supplier;
		private IEnumerable<Plan> _plans;

		public event Action<Supplier> SupplierSelected = supplier => { };
		public event Action<Plan> PlanSelected = plan => { };
		public event EventHandler LoadDefaults = (sender, args) => { };

		public string EnergyType
		{
			get; set;
		}

		public IEnumerable<Supplier> Suppliers
		{
			get 
			{
				return _supplier;
			}
			set
			{
				_supplier = value;
				suppliersCombo.ItemsSource = value.Select(x => x.Name);
			}
		}

		public IEnumerable<Plan> Plans
		{
			get
			{
				return _plans;
			}
			set
			{
				_plans = value;
				planCombo.ItemsSource = value.Select(x => x.Name);
			}
		}

		public Supplier SelectedSupplier
		{
			get
			{
				return Suppliers.Single(s => s.Name.Equals((string) suppliersCombo.SelectedItem));
			}
			set
			{
				suppliersCombo.SelectedItem = value.Name;
			}
		}

		public Plan SelectedPlan
		{
			get
			{
				return Plans.Single(s => s.Name.Equals((string)planCombo.SelectedItem));
			}
			set
			{
				planCombo.SelectedItem = value.Name;
			}
		}

		public EnergyUsageControl()
		{
			EnergyType = "Gas";

			// Required to initialize variables
			InitializeComponent();

			EnergyUsagePresenter presenter = EnergyType.Equals("Gas") ? (EnergyUsagePresenter) new GasUsagePresenter(this) : new ElectricityUsagePresenter(this);

			Loaded += (sender, args) => LoadDefaults(sender, args);
			suppliersCombo.SelectionChanged += SupplierComboChanged;
			planCombo.SelectionChanged += PlanComboChanged;
		}

		void SupplierComboChanged(object sender, SelectionChangedEventArgs e)
		{
			SupplierSelected(SelectedSupplier);
		}

		void PlanComboChanged(object sender, SelectionChangedEventArgs e)
		{
			PlanSelected(SelectedPlan);
		}
	}
}