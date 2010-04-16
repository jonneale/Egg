using System;
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
using uSwitch.Energy.Silverlight.Rest;

namespace uSwitch.Energy.Silverlight
{
	public partial class ResultsTable : UserControl
	{
		public ResultsTable()
		{
			// Required to initialize variables
			InitializeComponent();

            Loaded += new RoutedEventHandler(ResultsTable_Loaded);
		}

	    void ResultsTable_Loaded(object sender, RoutedEventArgs e)
        {
	        var client = RestClientFactory.GetDefault();
            var request = new ComparisonRequest
                              {
                                  ComparisonPaymentMethod = PaymentMethods.FixedMonthlyDirectDebit,
                                  ElectricityAnnualConsumptionKwh = 3300.0,
                                  ElectricityPaymentMethod = PaymentMethods.PayOnReceiptOfBill,
                                  ElectricitySupplierName = "british gas",
                                  ElectricityPlanKey = "standard",
                                  HasGas = true,
                                  GasAnnualConsumptionKwh = 20000,
                                  GasPlanKey = "standard",
                                  GasSupplierName = "british gas",
                                  GasPaymentMethod = PaymentMethods.PayOnReceiptOfBill,
                                  PostCode = "ub9 4dw"
                              };
            var command = new CompareCommand(request);
            command.Execute(client, ResultsTableCallBack);
        }

        protected void ResultsTableCallBack(Comparison comparison)
        {
            Dispatcher.BeginInvoke(() =>
                                       {
                                           resultsGrid.ItemsSource = comparison.ComparisonResults;
                                       });
        }
	}
}