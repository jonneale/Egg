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
using uSwitch.Energy.Silverlight.Core;
using uSwitch.Energy.Silverlight.Model;

namespace uSwitch.Energy.Silverlight.Events
{
    public class CompareEvent : IEvent
    {
        public string GasPaymentMethod
        {
            get; set;
        }

        public string ElectricityPaymentMethod
        {
            get; set;
        }

        public Supplier ElectricitySupplier
        {
            get; set;
        }

        public Supplier GasSupplier
        {
            get;
            set;
        }

        public Plan ElectricityPlan
        {
            get; set;
        }

        public Plan GasPlan
        {
            get; set;
        }

        public string ComparisonPaymentMethod
        {
            get; set;
        }

        public string Postcode
        {
            get; set;
        }

        public double ElectricityAnnualConsumptionKwh { get; set; }

        public double GasAnnualConsumptionKwh { get; set; }

        public bool HasGas { get; set; }

        public bool IsEconomy7 { get; set; }

        public double ElectricityAnnualSpend { get; set; }

        public double GasAnnualSpend { get; set; }
    }
}
