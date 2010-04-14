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

namespace uSwitch.Energy.Silverlight.Model
{
    public class DefaultEnergyResult
    {
        public string DefaultElectricityPlan
        {
            get; set;
        }

        public string DefaultElectricitySupplier
        {
            get;
            set;
        }

        public string DefaultGasPlan
        {
            get;
            set;
        }

        public string DefaultGasSupplier
        {
            get;
            set;
        }

        public string Name
        {
            get; set;
        }
    }
}
