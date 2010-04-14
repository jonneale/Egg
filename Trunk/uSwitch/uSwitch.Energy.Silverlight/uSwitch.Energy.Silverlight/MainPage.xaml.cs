using System;
using System.Windows;
using System.Windows.Controls;
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

			//comparisonResultsTable.Visibility = Visibility.Visible;
			//currentSuppliersCanvas.Visibility = Visibility.Collapsed;
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

		private void FindRegionButton_Click(object sender, RoutedEventArgs e)
		{
			FindRegionPressed(postcodeTextBox.Text);
		}
	}
}