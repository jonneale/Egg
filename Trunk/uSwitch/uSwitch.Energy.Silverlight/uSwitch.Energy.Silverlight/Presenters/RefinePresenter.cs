using System;
using System.Windows.Threading;
using uSwitch.Energy.Silverlight.Core;
using uSwitch.Energy.Silverlight.Events;
using uSwitch.Energy.Silverlight.Model;
using uSwitch.Energy.Silverlight.Views;

namespace uSwitch.Energy.Silverlight.Presenters
{
	public class RefinePresenter
	{
		private readonly IRefineView _view;
		private readonly Dispatcher _dispatcher;
		private readonly IEventHub _eventHub = EventHub.GetCurrent();

		public RefinePresenter(IRefineView control, Dispatcher dispatcher)
		{
			_view = control;
			_dispatcher = dispatcher;
		}

		public void Loaded()
		{
			_view.PaymentMethods = PaymentMethods.GetAll();

			Action<ComparisonRefinedEvent> callBack = ComparisonRefinedCallback;
			_eventHub.Register(callBack);
		}
		
		private void ComparisonRefinedCallback(ComparisonRefinedEvent @event)
		{
			_view.IsVisible = true;
		}

		public void RefineResults(string paymentMethod)
		{
			_eventHub.Publish(new ComparisonRefinedEvent { PaymentMethod = paymentMethod});
		}
	}
}