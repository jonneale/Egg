using System;
using System.Collections.Generic;

namespace uSwitch.Energy.Silverlight.Core
{
	public class EventHub : IEventHub
	{
		private static readonly EventHub _instance = new EventHub();
		private readonly Dictionary<Type, List<object>> _eventHandlers = new Dictionary<Type, List<object>>();

		public static EventHub GetCurrent()
		{
			return _instance;
		}

		public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
		{
			if (_eventHandlers.ContainsKey(typeof(TEvent)))
			{
				foreach (object handler in _eventHandlers[typeof(TEvent)])
				{
					var callBack = (Action<TEvent>) handler;
					callBack(@event);
				}
			}
		}

		public void Register<TEvent>(Action<TEvent> eventHandler) where TEvent : IEvent
		{
			if (!_eventHandlers.ContainsKey(typeof(TEvent)))
			{
				_eventHandlers.Add(typeof (TEvent), new List<object>());
				_eventHandlers[typeof (TEvent)].Add(eventHandler);
			}
		}
	}
}