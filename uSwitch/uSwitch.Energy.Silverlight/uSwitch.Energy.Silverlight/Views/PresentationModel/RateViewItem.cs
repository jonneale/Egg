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
using uSwitch.Energy.Silverlight.Model;

namespace uSwitch.Energy.Silverlight.Views.PresentationModel
{
    public class RateViewItem
    {
        public string StartingRateText
        {
            get; protected set;
        }

        public string Price
        {
            get; protected set;
        }

        public string Tier
        {
            get;
            protected set;
        }

        public RateViewItem(int rateIndex, Rate rate)
        {
            Tier = "Tier " + (rateIndex + 1) + " - ";
            StartingRateText = string.Format("Prices start at unit: {0} kWh", rate.StartUnit);
            Price = string.Format("Unit rates: {0} per kWh", rate.PencePerkWh);
        }
    }
}
