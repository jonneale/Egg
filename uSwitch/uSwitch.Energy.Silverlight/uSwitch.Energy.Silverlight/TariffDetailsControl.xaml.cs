using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using uSwitch.Energy.Silverlight.Model;
using uSwitch.Energy.Silverlight.Presenters;
using uSwitch.Energy.Silverlight.Rest;
using uSwitch.Energy.Silverlight.Views;

namespace uSwitch.Energy.Silverlight
{
    public partial class TariffDetailsControl : UserControl, ITariffView
    {
		public TariffDetailsControl()
        {
            InitializeComponent();

            Loaded += TariffPopupControl_Loaded;
        }

        protected void TariffPopupControl_Loaded(object sender, RoutedEventArgs e)
        {
            var presenter = new TariffPresenter(this, Dispatcher, RestClientFactory.GetDefault());
            presenter.Loaded();
        }

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
        public string ElectricityUnitRates
        {
            get
            {
                return electricityUnitRatesTextBlock.Text;
            }
            set
            {
                electricityUnitRatesTextBlock.Text = value;
            }
        }
        public string GasUnitRates
        {
            get
            {
                return gasUnitRatesTextBlock.Text;
            }
            set
            {
                gasUnitRatesTextBlock.Text = value;
            }
        }

    	public IEnumerable<Rate> SelectedPlanGasRates
    	{
    		get
    		{
    			return (IEnumerable<Rate>) gasRatesListBox.ItemsSource;
    		}
			set
			{
				gasRatesListBox.ItemsSource = value;
			}
    	}

		public IEnumerable<Rate> SelectedPlanElectricityRates
		{
			get
			{
				return (IEnumerable<Rate>)electricityRatesListBox.ItemsSource;
			}
			set
			{
				electricityRatesListBox.ItemsSource = value;
			}
		}
    }
}
