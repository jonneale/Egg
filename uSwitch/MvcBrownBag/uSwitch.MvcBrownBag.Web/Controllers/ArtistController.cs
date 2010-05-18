using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uSwitch.MvcBrownBag.Domain;
using uSwitch.MvcBrownBag.Domain.Repository;
using uSwitch.MvcBrownBag.Web.Models;

namespace uSwitch.MvcBrownBag.Web.Controllers
{
    public class ArtistController : Controller
    {
    	private readonly IRepository _repository;

    	public ArtistController(IRepository repository)
    	{
    		_repository = repository;
    	}

    	public ActionResult Index()
        {
            return View();
        }

		public ActionResult Details(int id)
		{
			var artist = _repository.Get<Artist>(id);

			return View(artist);
		}

		public ActionResult Create(CreateArtistView createArtistView)
		{
			if (ModelState.IsValid)
			{
				var artist = new Artist(createArtistView.Name, createArtistView.BandName);
				_repository.Add(artist);
			}
			return View();
		}
    }
}
