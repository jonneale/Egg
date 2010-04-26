﻿using System;
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
		public event Action<string> PaymentMethodSelected = paymentMethod => { };

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

		public bool HasGas
		{
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
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

            usageTextBlock.Text = string.Format("{0} usage", Product);

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