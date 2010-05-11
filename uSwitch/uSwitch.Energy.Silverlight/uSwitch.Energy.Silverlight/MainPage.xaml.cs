using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using uSwitch.Energy.Silverlight.Model;
using uSwitch.Energy.Silverlight.Presenters;
using uSwitch.Energy.Silverlight.Views;

namespace uSwitch.Energy.Silverlight
{
	public partial class MainPage : UserControl, IApplicationView
	{
        private string _region;

		public MainPage()
		{
			// Required to initialize variables
			InitializeComponent();

			Loaded += MainPage_Loaded;

            postcodeTextBox.GotFocus += postcodeTextBox_GotFocus;
            compareUsageButton.Click += compareUsageButton_Click;
		}

        protected void compareUsageButton_Click(object sender, RoutedEventArgs e)
        {
            Compare();
        }

        protected void postcodeTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            postcodeTextBox.Text = string.Empty;
        }

		protected void MainPage_Loaded(object sender, RoutedEventArgs e)
		{
			var presenter = new ApplicationPresenter(this, Dispatcher);
            presenter.Loaded();
		}

        public DefaultRegionInformation DefaultUsage
        {
            get; set;
        }

	    public string Region
		{
			get { return _region; }
			set
			{
				currentRegionTextBlock.Text = string.Format("Selected region: {0}", value);
				_region = value;
			}
		}

		public string Postcode { get; set; }

	    public bool HasGas
	    {
	        get; set;
	    }

		public bool HasEconomy7
		{
			get; set;
		}

		public string PaymentMethod
		{
			get; set;
		}

		public event Action<string> FindRegionPressed = s => { };
        public event Action<bool> HasGasChanged = g => { };
	    public event Action Compare = () => {};

	    public Storyboard UsageFadeInStoryboard
	    {
	        get 
            {
	            return UsageFadeIn;
            }
	    }

        public IEnergyUsageView GasUsageView 
        { 
            get
            {
                return gasUsageControl;
            } 
        }
	    public IEnergyUsageView ElectricityUsageView
	    {
	        get
	        {
	            return electricityUsageControl;
	        }
	    }

	    public bool UsagePanelsVisible
	    {
	        get
	        {
	            return currentSuppliersCanvas.Visibility == Visibility.Visible;
	        }
	        set
	        {
	            currentSuppliersCanvas.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
                compareUsageButton.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
                hasE7AndGasStackPanel.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
	        }
	    }

	    public bool InitialQuestionsVisible
	    {
	        get
	        {
	            return postcodeTextBox.Visibility == Visibility.Visible;
	        }
	        set
	        {
	            var visibility = value ? Visibility.Visible : Visibility.Collapsed;
	            postcodeTextBlock.Visibility = visibility;
                postcodeTextBox.Visibility = visibility;
	            findRegionButton.Visibility = visibility;
	            currentRegionTextBlock.Visibility = visibility;
	        }
	    }

	    public bool DisplayResultsOnly
	    {
	        get
	        {
	            return comparisonResultsTable.Visibility == Visibility.Visible;
	        }
	        set
	        {
	            comparisonResultsTable.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
                currentSuppliersCanvas.Visibility = value ? Visibility.Collapsed : Visibility.Visible;
                hasE7AndGasStackPanel.Visibility = value ? Visibility.Collapsed : Visibility.Visible;
                postcodeStackPanel.Visibility = value ? Visibility.Collapsed : Visibility.Visible;
                compareUsageButton.Visibility = value ? Visibility.Collapsed : Visibility.Visible;
	        }
	    }

	    private void FindRegionButton_Click(object sender, RoutedEventArgs e)
		{
			FindRegionPressed(postcodeTextBox.Text);
		}

        private void moveToDesktopButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Install();
        }

        private void TextBlock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                FindRegionPressed(postcodeTextBox.Text);
            }
        }

        private void HasGasRadio_Checked(object sender, RoutedEventArgs e)
        {
            HasGasChanged(true);
        }

        private void HasntGasRadio_Checked(object sender, RoutedEventArgs e)
        {
            HasGasChanged(false);
        }

		private void HasEconomy7Radio_Checked(object sender, RoutedEventArgs e)
		{
			HasGasChanged(true);
		}

		private void HasntEconomy7Radio_Checked(object sender, RoutedEventArgs e)
		{
			HasGasChanged(false);
		}
	}
}