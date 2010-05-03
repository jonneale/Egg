using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
		public event Action<string> PaymentMethodSelected = paymentMethod => { };

		public bool IsVisible
		{
			get
			{
				return Visibility == Visibility.Visible;
			}
			set
			{
				Visibility = value ? Visibility.Visible : Visibility.Collapsed;
			}
		}

		public double Amount
		{
			get
			{
				return double.Parse(Regex.Match(usageAmountTextbox.Text, @"\d.").Value);
			}
			set
			{
				usageAmountTextbox.Text = value.ToString();
			}
		}

		public bool IsInKwh
		{
			get
			{
				return Regex.Match(usageAmountTextbox.Text, @"Kwh", RegexOptions.IgnorePatternWhitespace).Success;
			}
		}

		public bool IsTransparent
		{
			get
			{
				return Opacity == 0;
			}
			set
			{
				Opacity = value ? 1 : 0;
			}
		}

		public IEnumerable<string> TimePeriods
		{
			get
			{
				return (IEnumerable<string>) timePeriodComboBox.ItemsSource;
			}
			set
			{
				timePeriodComboBox.ItemsSource = value;
			}
		}

		public string SelectedTimePeriod
		{
			get
			{
				return (string) timePeriodComboBox.SelectedItem;
			}
			set
			{
				timePeriodComboBox.SelectedItem = TimePeriods.Where(x => x.Equals(value)).Single();
			}
		}

		public string HeaderText
	    {
	        get
	        {
	            return consumptionHeader.Text;
	        }
            set
            {
                consumptionHeader.Text = value;
            }
	    }

		public string Region
		{
			get; set;
		}

		public string PaymentMethod
		{
			get
			{
				return (string) paymentMethodCombo.SelectedItem;
			}
			set
			{
				paymentMethodCombo.SelectedItem = value;
			}
		}

	    public string RegionDefaultPlanName { get; set; }

	    public string Product
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
                suppliersCombo.SelectedIndex = 0;
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
				planCombo.SelectedIndex = 0;
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

	    public string RegionDefaultSupplierName { get; set; }

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

	    public double UsageInKwh
	    {
	        get
	        {
	            return double.Parse(usageAmountTextbox.Text);
	        }
	        set
	        {
	            usageAmountTextbox.Text = value.ToString();
	        }
	    }

	    public EnergyUsageControl()
		{
			// Required to initialize variables
			InitializeComponent();

			Loaded += EnergyUsageControl_Loaded;
		}

		void EnergyUsageControl_Loaded(object sender, RoutedEventArgs e)
		{
			paymentMethodCombo.ItemsSource = PaymentMethods.GetAll();
			paymentMethodCombo.SelectedIndex = 0;

			EnergyUsagePresenter presenter = GetPresenter();

			suppliersCombo.SelectionChanged += SupplierComboChanged;
			planCombo.SelectionChanged += PlanComboChanged;
			paymentMethodCombo.SelectionChanged += PaymentMethodComboChanged;

            usageTextBlock.Text = string.Format("{0} spend", Product);

			presenter.Loaded();
		}

		private EnergyUsagePresenter GetPresenter()
		{
			return Product.Equals("Gas") ? (EnergyUsagePresenter)new GasUsagePresenter(this, Dispatcher) : new ElectricityUsagePresenter(this, Dispatcher);
		}

		void SupplierComboChanged(object sender, SelectionChangedEventArgs e)
		{
            if (e.AddedItems.Count > 0)
            {
                SupplierSelected(SelectedSupplier);
            }
		}

		void PlanComboChanged(object sender, SelectionChangedEventArgs e)
		{
            if (e.AddedItems.Count > 0)
            {
                PlanSelected(SelectedPlan);
            }
		}

		void PaymentMethodComboChanged(object sender, SelectionChangedEventArgs e)
		{
            if (e.AddedItems.Count > 0)
            {
                PaymentMethodSelected(PaymentMethod);
            }
		}
	}
}