using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uSwitch.MvcBrownBag.Domain;
using uSwitch.MvcBrownBag.Domain.Repository;
using uSwitch.MvcBrownBag.Web.Core.ActionResults;

namespace uSwitch.MvcBrownBag.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly IRepository _repository;

        public EventController(IRepository repository)
        {
            this._repository = repository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public CsvResult GetCsv()
        {
            //var events = _repository.All<Event>();

        	var events = new[]
        	             	{
        	             		new Event() {Name = "jamie", ShowTime = DateTime.Now},
        	             		new Event() {Name = "Nicky", ShowTime = DateTime.Now}
        	             	};

            var simpleEvents = events.Select(x => new {EventName = x.Name, x.ShowTime});
            return new CsvResult(simpleEvents);
        }
    }
}
