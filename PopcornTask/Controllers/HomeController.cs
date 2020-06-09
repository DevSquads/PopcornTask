using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PopcornTask.Controllers {
	public class HomeController : BaseController {
		private PopcornTask.Models.PopcornDataEntities db = new Models.PopcornDataEntities();

		public ActionResult Index() {
			ViewBag.Popcorns = db.Popcorns.ToList();

			return View("Index");
		}

	}
}