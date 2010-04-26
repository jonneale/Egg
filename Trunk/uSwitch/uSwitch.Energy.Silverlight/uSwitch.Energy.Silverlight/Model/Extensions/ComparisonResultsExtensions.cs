using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using uSwitch.Energy.Silverlight.Views.PresentationModel;

namespace uSwitch.Energy.Silverlight.Model.Extensions
{
    public static class ComparisonResultsExtensions
    {
        public static IEnumerable<ResultsViewItem> ToResultsViewItems(this IEnumerable<ComparisonResult> results)
        {
            return results.Select(x => new ResultsViewItem
            {
                PlanTitle = string.Format("{0}\n{1}", x.SupplierName, x.PlanName),
                Savings = x.Savings,
                Price = x.Price,
                SwitchUrl = x.SwitchUrl
            }).ToList();
        }
    }
}
