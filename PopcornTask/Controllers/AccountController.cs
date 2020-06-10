using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PopcornTask.Models;
using PopcornTask.Shared;

namespace PopcornTask.Controllers
{
    public class AccountController : BaseController
    {
		private PopcornDataEntities db = new PopcornDataEntities();
		public ActionResult Login()
        {
			if(SessionContainer.User != null) return Index();

			return View("Login");
        }
		public ActionResult Index() {
			return RedirectToAction("Index", "Home");
		}
		public bool validateUserData(SystemUser user, out SystemUser dbuser) {
			var _dbuser = db.SystemUsers.Where(u => u.Username == user.Username);
			if(_dbuser.Any()) if(_dbuser.FirstOrDefault().Password.Trim() == user.Password.Trim()) {
					dbuser = _dbuser.FirstOrDefault();
					return true;
			}
			dbuser = null;
			return false;
		}
		[HttpPost]
		public ActionResult Login(SystemUser user, string to) {
			SystemUser dbuser;
			if(ModelState.IsValid) if(validateUserData(user, out dbuser)) {
					SessionContainer.User = dbuser;
					if(!string.IsNullOrEmpty(to)) {
						string[] urlComponents = to.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
						var index = Url.Content("~").Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Count();
						if(urlComponents.Count() > index) {
							var controller = urlComponents[index];
							return RedirectToAction("Index", controller);
						}
					}
					return Index();
			}
			ModelState.AddModelError("", "Error! entered wrong data!");
			SessionContainer.User = null;
			return View(user);
		}
		[HttpGet]
		public ActionResult Logout() {
			Session.Abandon();
			Session.Clear();
			Session.RemoveAll();
			return RedirectToAction("Login", "Account");
		}
	}
}