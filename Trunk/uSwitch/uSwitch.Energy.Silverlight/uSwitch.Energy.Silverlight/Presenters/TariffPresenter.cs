using System;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using uSwitch.Energy.Silverlight.Core;
using uSwitch.Energy.Silverlight.Events;
using uSwitch.Energy.Silverlight.Model;
using uSwitch.Energy.Silverlight.Queries;
using uSwitch.Energy.Silverlight.Views;

namespace uSwitch.Energy.Silverlight.Presenters
{
    public class TariffPresenter
    {
        private readonly ITariffView _view;
        private readonly Dispatcher _dispatcher;
        private readonly IEventHub _eventHub = EventHub.GetCurrent();

        public TariffPresenter(ITariffView view, Dispatcher dispatcher)
        {
            _view = view;
            _dispatcher = dispatcher;
        }

        public void Loaded()
        {
            Action<TariffInformationFoundEvent> eventCallBack = TariffInformationFoundEventCallback;
            _eventHub.Register(eventCallBack);
        }

        protected void TariffInformationFoundEventCallback(TariffInformationFoundEvent @event)
        {
            DisplayTariffRates(@event.ElectricityTariff, @event.GasTariff);
        }

        public void DisplayTariffRates(Tariff electricity, Tariff gas)
        {
            _view.IsVisible = true;

            _view.ElectricityUnitRates = string.Format("Current electricity rates: {0}",
                                                       electricity.Rates.ElementAt(0).PencePerkWh);

            _view.GasUnitRates = string.Format("Current electricity rates: {0}",
                                                       electricity.Rates.ElementAt(0).PencePerkWh);
        }

        public void HideTariffRates()
        {
            _view.IsVisible = false;
        }
    }
}