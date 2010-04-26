using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using uSwitch.Energy.Silverlight.Model;
using uSwitch.Energy.Silverlight.Queries;
using uSwitch.Energy.Silverlight.Rest;

namespace uSwitch.Energy.Silverlight
{
    public partial class RestTests : UserControl
    {
        public RestTests()
        {
            InitializeComponent();
        }

        private void findAllSuppliersButton_Click(object sender, RoutedEventArgs e)
        {
            var query = new AllSuppliersForProductAndRegionQuery(Products.Gas, "southern");
            query.Execute(RestClientFactory.GetDefault(), s => Dispatcher.BeginInvoke(() =>
                                                                                          {
                                                                                              resultsTextBlock.Text = string.Join(",",
                                                                                                                                  s.Select(
                                                                                                                                      x => x.Name).ToArray());
                                                                                          }));

        }

        private void findregion_Click(object sender, RoutedEventArgs e)
        {
            var query = new GetRegionFromPostCodeQuery(postcodeTextbox.Text);
            query.Execute(RestClientFactory.GetDefault(), s => Dispatcher.BeginInvoke(() =>
                                                                                          {
                                                                                              findregionTextBlock.Text =
                                                                                                  string.Concat(
                                                                                                      "Postcode: ",
                                                                                                      s.Postcode,
                                                                                                      ", Region:",
                                                                                                      s.RegionName);
                                                                                          }
                                                                   ));
        }
    }
}
