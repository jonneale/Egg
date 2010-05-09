using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using BensBoxing.Domain;

namespace BensBoxing.Web.Controllers
{
    public class MatchController : BaseController
    {
        //
        // GET: /Match/

        public ActionResult Index()
        {
            var repository = GetRepository<Match>();
            var match = repository.Get(1000);
            return View(match);
        }

    }
}
