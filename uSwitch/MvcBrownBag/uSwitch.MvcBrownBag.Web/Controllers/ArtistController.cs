using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uSwitch.MvcBrownBag.Domain;
using uSwitch.MvcBrownBag.Domain.Repository;
using uSwitch.MvcBrownBag.Web.Models;
using uSwitch.MvcBrownBag.Web.Attributes;

namespace uSwitch.MvcBrownBag.Web.Controllers
{
    [PageMetaFilter(Description = "The artist description", Title = "I'm the artist")]
    public class ArtistController : Controller
    {
    	private readonly IRepository _repository;

    	public ArtistController(IRepository repository)
    	{
    		_repository = repository;
    	}

    	public ActionResult Index()
        {
    	    var artists = _repository.All<Artist>();

            return View("All", artists);
        }

		public ActionResult Details(int id)
		{
			var artist = _repository.Get<Artist>(id);
			return View(artist);
		}

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
		public ActionResult Create(CreateArtistView createArtistView)
		{
			if (ModelState.IsValid)
			{
				var artist = new Artist(createArtistView.Name, createArtistView.BandName) {DOB = new DateTime(1983, 5, 2)};
			    artist.Comments = string.Empty;
			    _repository.Add(artist);
			    return RedirectToAction("index");
			}
			return View();
		}
    }
}
