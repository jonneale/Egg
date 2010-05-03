using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using MVC2Application.Web.Core.Persistance;
using MVC2Application.Web.PresentationModel;
using MVC2Application.Web.PresentationModel.Extensions;

namespace MVC2Application.Web.Controllers
{
    public class CustomerController : Controller
    {
    	protected CustomerRepository _customerRepository = CustomerRepository.GetSingleton();

        public ActionResult Index()
        {
        	var customers = _customerRepository.All();
			var viewOfCustomers = Mapper.Map<IEnumerable<Persistance.Domain.Customer>
				, IEnumerable<Customer>>(customers);

			return View(viewOfCustomers);
        }

		[ActionName("Details")]
		public ActionResult Details(string name) {
			return View(_customerRepository.All().Where(
				x => string.Concat(x.FirstName, " ", x.LastName).Equals(name)));
		}

		[HttpGet]
		public ActionResult Create() {
			return View(new CreateCustomer());
		}

		[HttpPost]
		public ActionResult Create(CreateCustomer customer) {
			if (ViewData.ModelState.IsValid) {
				_customerRepository.Add(customer.ToCustomer());
				return new RedirectToRouteResult(new RouteValueDictionary(new {controller = "customer", action = "index"}));
			}

			return View();
		}
    }
}
