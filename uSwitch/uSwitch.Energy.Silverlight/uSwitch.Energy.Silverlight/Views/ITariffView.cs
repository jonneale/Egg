namespace uSwitch.Energy.Silverlight.Views
{
    public interface ITariffView
    {
        bool IsVisible { get; set; }

        string ElectricityUnitRates { get; set; }

        string GasUnitRates { get; set; }
    }
}