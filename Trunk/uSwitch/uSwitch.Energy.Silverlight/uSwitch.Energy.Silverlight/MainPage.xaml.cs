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
	public partial class MainPage : UserControl, IComparisonView
	{
		public MainPage()
		{
			// Required to initialize variables
			InitializeComponent();

			Loaded += MainPage_Loaded;

            postcodeTextBox.GotFocus += new RoutedEventHandler(postcodeTextBox_GotFocus);

			//comparisonResultsTable.Visibility = Visibility.Visible;
			//currentSuppliersCanvas.Visibility = Visibility.Collapsed;
		}

        void postcodeTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            postcodeTextBox.Text = string.Empty;
        }

		protected void MainPage_Loaded(object sender, RoutedEventArgs e)
		{
			var presenter = new ComparisonPresenter(this, Dispatcher);
		}

		private string _region;

		public string Region
		{
			get { return _region; }
			set
			{
				currentRegionTextBlock.Text = value;
				_region = value;
			}
		}

		public string Postcode { get; set; }

		public event Action<string> FindRegionPressed = s => { };

	    public Storyboard UsageFadeInStoryboard
	    {
	        get 
            {
	            return UsageFadeIn;
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
	}
}