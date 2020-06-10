using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PopcornTask.Models;

namespace PopcornTask.Shared {
	public class SessionContainer {
		public static SystemUser User {
			get { return HttpContext.Current.Session == null || HttpContext.Current.Session["SystemUser"] == null ? null : HttpContext.Current.Session["SystemUser"] as SystemUser; }
			set { HttpContext.Current.Session["SystemUser"] = value; }
		}
	}
}