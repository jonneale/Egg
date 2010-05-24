
using System;
using System.Threading;
using uSwitch.MvcBrownBag.Domain;

namespace uSwitch.MvcBrownBag.Web.Core
{
	public class EventSignupService
	{
		public EventHandler SignUpCompleted = (sender, args) => { };

		public void SignUpAsync(Event @event)
		{
			WaitCallback callback = state => { 
				Thread.Sleep(6000);
				SignUpCompleted(this, EventArgs.Empty);
			};
			ThreadPool.QueueUserWorkItem(callback);
		}
	}
}