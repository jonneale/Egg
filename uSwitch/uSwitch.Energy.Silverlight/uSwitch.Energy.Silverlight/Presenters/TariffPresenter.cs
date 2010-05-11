using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using uSwitch.Energy.Silverlight.Core;
using uSwitch.Energy.Silverlight.Events;
using uSwitch.Energy.Silverlight.Model;
using uSwitch.Energy.Silverlight.Queries;
using uSwitch.Energy.Silverlight.Rest;
using uSwitch.Energy.Silverlight.Views;
using uSwitch.Energy.Silverlight.Views.PresentationModel;

namespace uSwitch.Energy.Silverlight.Presenters
{
    public class TariffPresenter
    {
        private readonly ITariffView _view;
        private readonly Dispatcher _dispatcher;
    	private readonly IRestClient _restClient;
    	private readonly IEventHub _eventHub = EventHub.GetCurrent();

        public TariffPresenter(ITariffView view, Dispatcher dispatcher, IRestClient restClient)
        {
            _view = view;
            _dispatcher = dispatcher;
        	_restClient = restClient;
        }

        public void Loaded()
        {
			Action<ResultSelected> resultsSelected = ResultSelectedCallBack;
			_eventHub.Register(resultsSelected);
        }

		public void DisplayTariffRates(Tariff electricity, Tariff gas)
        {
            _view.IsVisible = true;

		    List<RateViewItem> electricityRates = GetRateItems(electricity);
		    _view.SelectedPlanElectricityRates = electricityRates.ToArray();

            List<RateViewItem> gasRates = GetRateItems(electricity);
            _view.SelectedPlanGasRates = gasRates.ToArray();

		    _view.StandingChargeText = string.Format("Standing charge: {0:C}", electricity.StandingCharge);
        }

        private static List<RateViewItem> GetRateItems(Tariff tariff)
        {
            var counter = 0;
            var electricityRates = new List<RateViewItem>();
            foreach (var rate in tariff.Rates)
            {
                electricityRates.Add(new RateViewItem(counter, rate));
                counter++;
            }
            return electricityRates;
        }

        private void ResultSelectedCallBack(ResultSelected resultSelected)
		{
			var queryElectricity = new GetTariffInfoForPlan(resultSelected.SupplierName,
				resultSelected.PlanKey,
				PaymentMethods.FixedMonthlyDirectDebit,
				Products.Electricity,
				resultSelected.Region);

			var queryGas = new GetTariffInfoForPlan(resultSelected.SupplierName,
				resultSelected.PlanKey,
				PaymentMethods.FixedMonthlyDirectDebit,
				Products.Electricity,
				resultSelected.Region);

			var state = new Tariff[2];

			queryElectricity.Execute(_restClient, tariff => CallDispatcher(() =>
			{
				lock (state)
				{
					state[0] = tariff;
					if (state[1] != null)
					{
						PublishTariffInformationFoundEvent(state);
					}
				}
			}));

			queryGas.Execute(_restClient, tariff => CallDispatcher(() =>
			{
				lock (state)
				{
					state[1] = tariff;
					if (state[0] != null)
					{
						PublishTariffInformationFoundEvent(state);
					}
				}
			}));
		}

		private void PublishTariffInformationFoundEvent(object[] tariffStateObjects)
		{
			PublishTariffInformationFoundEvent((Tariff)tariffStateObjects[0], (Tariff)tariffStateObjects[1]);
		}

		private void PublishTariffInformationFoundEvent(Tariff electricity, Tariff gas)
		{
			_eventHub.Publish(new TariffInformationFoundEvent { ElectricityTariff = electricity, GasTariff = gas });
			DisplayTariffRates(electricity, gas);
		}

        public void HideTariffRates()
        {
            _view.IsVisible = false;
        }

		protected void CallDispatcher(Action action)
		{
			_dispatcher.BeginInvoke(action);
		}
    }
}