using System.Collections.Generic;
using uSwitch.Energy.Silverlight.Views.PresentationModel;

namespace uSwitch.Energy.Silverlight.Views
{
    public interface ITariffView
    {
        bool IsVisible { get; set; }

        IEnumerable<RateViewItem> SelectedPlanGasRates { get; set; }
        IEnumerable<RateViewItem> SelectedPlanElectricityRates { get; set; }
        string StandingChargeText { get; set; }
    }
}