using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using uSwitch.Energy.Silverlight.Presenters;
using uSwitch.Energy.Silverlight.Rest;
using uSwitch.Energy.Silverlight.Views;
using uSwitch.Energy.Silverlight.Views.PresentationModel;

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
        public IEnumerable<RateViewItem> SelectedPlanGasRates
    	{
    		get
    		{
                return (IEnumerable<RateViewItem>)gasRatesListBox.ItemsSource;
    		}
			set
			{
				gasRatesListBox.ItemsSource = value;
			}
    	}

        public IEnumerable<RateViewItem> SelectedPlanElectricityRates
		{
			get
			{
                return (IEnumerable<RateViewItem>)electricityRatesListBox.ItemsSource;
			}
			set
			{
				electricityRatesListBox.ItemsSource = value;
			}
		}
    }
}
