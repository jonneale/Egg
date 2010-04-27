using uSwitch.Energy.Silverlight.Core;
using uSwitch.Energy.Silverlight.Model;

namespace uSwitch.Energy.Silverlight.Events
{
    public class TariffInformationFoundEvent : IEvent
    {
        public Tariff ElectricityTariff
        {
            get; set;
        }

        public Tariff GasTariff
        {
            get;
            set;
        }
    }
}