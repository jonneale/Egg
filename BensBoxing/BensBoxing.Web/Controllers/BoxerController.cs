using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using NHibernate;
using BensBoxing.Domain.Repositories;
using BensBoxing.Domain;

namespace BensBoxing.Web.Controllers
{
    public class BoxerController : BaseController
    {
        public BoxerController()
        {
           
        }

        public ActionResult Index()
        {
            var repository = GetRepository<Boxer>();
            var boxers = repository.All();
            return View(boxers);
        }
    }
}
