using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using uSwitch.Energy.Silverlight.Commands;
using uSwitch.Energy.Silverlight.Model;
using uSwitch.Energy.Silverlight.Presenters;
using uSwitch.Energy.Silverlight.Rest;
using uSwitch.Energy.Silverlight.Views;
using uSwitch.Energy.Silverlight.Views.PresentationModel;
using System.Linq;

namespace uSwitch.Energy.Silverlight
{
	public partial class ResultsTable : UserControl, IResultsView
	{
	    public event Action<ResultsViewItem> ResultSelected = item => { };

		public ResultsTable()
		{
			// Required to initialize variables
			InitializeComponent();

            Loaded += ResultsTableLoaded;
		}

        protected void ResultsTableLoaded(object sender, RoutedEventArgs e)
        {
            var presenter = new ResultsPresenter(this, Dispatcher);
            presenter.Loaded();
        }

	    public IEnumerable<ResultsViewItem> Results
	    {
	        get
	        {
	            return (IEnumerable<ResultsViewItem>) resultsGrid.ItemsSource;
	        }
	        set
	        {
	            resultsGrid.ItemsSource = value;
	        }
	    }

	    public bool DisplayTable
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

        private void resultsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = e.AddedItems.Cast<ResultsViewItem>().FirstOrDefault();

            if (selected != null)
            {
                ResultSelected(selected);
            }
        }
	}
}