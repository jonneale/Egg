using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace uSwitch.Energy.Silverlight.Views.PresentationModel
{
    public class ResultsViewItem
    {
        public string SupplierName { get; set; }
        public string PlanName { get; set; }
        public string PlanTitle { get; set; }
        public string PlanKey { get; set; }
        public double Price { get; set; }
        public double Savings { get; set; }
        public string SwitchUrl { get; set; }
    }
}
