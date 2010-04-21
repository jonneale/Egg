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

namespace uSwitch.Energy.Silverlight
{
	public partial class ResultsTable : UserControl, IResultsView
	{
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


        //void ResultsTable_Loaded(object sender, RoutedEventArgs e)
        //{
        //    var client = RestClientFactory.GetDefault();
        //    var request = new ComparisonRequest
        //                      {
        //                          ComparisonPaymentMethod = PaymentMethods.FixedMonthlyDirectDebit,
        //                          ElectricityAnnualConsumptionKwh = 3300.0,
        //                          ElectricityPaymentMethod = PaymentMethods.PayOnReceiptOfBill,
        //                          ElectricitySupplierName = "british gas",
        //                          ElectricityPlanKey = "standard",
        //                          HasGas = true,
        //                          GasAnnualConsumptionKwh = 20000,
        //                          GasPlanKey = "standard",
        //                          GasSupplierName = "british gas",
        //                          GasPaymentMethod = PaymentMethods.PayOnReceiptOfBill,
        //                          PostCode = "ub9 4dw"
        //                      };
        //    var command = new CompareCommand(request);
        //    command.Execute(client, ResultsTableCallBack);
        //}

        //protected void ResultsTableCallBack(Comparison comparison)
        //{
        //    var resultsView = comparison.ComparisonResults.Select(x => new ResultsViewItem
        //                                                                   {
        //                                                                       Plan = string.Format("{0}\n{1}", x.SupplierName, x.PlanName), 
        //                                                                       Savings = x.Savings, 
        //                                                                       Price = x.Price,
        //                                                                       SwitchUrl = x.SwitchUrl
        //                                                                   }).ToList();

        //    Dispatcher.BeginInvoke(() =>
        //                               {
        //                                   resultsGrid.ItemsSource = resultsView;
        //                               });
        //}

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
	}
}