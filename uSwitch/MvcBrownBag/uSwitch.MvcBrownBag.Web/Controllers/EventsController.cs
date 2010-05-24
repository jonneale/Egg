using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uSwitch.MvcBrownBag.Domain;
using uSwitch.MvcBrownBag.Web.Core;

namespace uSwitch.MvcBrownBag.Web.Controllers
{
	public class EventsController : AsyncController
	{
		public void RegisterAsync(int id)
		{
			var @event = new Event {Name = "My event"};
			var service = new EventSignupService();
			var emailService = new EmailSender();

			AsyncManager.OutstandingOperations.Increment(2);

			DateTime startTime = DateTime.Now;

			service.SignUpCompleted += (sender, args) =>
			                           	{

			                           		AsyncManager.OutstandingOperations.Decrement(1);
			                           		AsyncManager.Parameters["signupSuccess"] = true;
											AsyncManager.Parameters["startTime"] = startTime;
			                           	};

			emailService.SignUpCompleted += (sender, args) =>
			{
				AsyncManager.OutstandingOperations.Decrement(1);
				AsyncManager.Parameters["emailSuccess"] = true;
			};

			service.SignUpAsync(@event);
			emailService.SignUpAsync(@event);
		}

		public ActionResult RegisterCompleted(bool emailSuccess, bool signupSuccess, DateTime startTime)
		{
			string result = string.Format("Start time: {0}\n Finish time {1}", startTime, DateTime.Now);

			return new ContentResult() {Content = result, ContentType = "text/plain"};
		}
	}
}
