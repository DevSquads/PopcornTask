using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PopcornTask;
using PopcornTask.Controllers;
using PopcornTask.Shared;

namespace PopcornTask.Tests.Controllers {
	[TestClass]
	public class HomeControllerTest {
		[TestMethod]
		public void IndexActionExists() {				
			var controller = new HomeController();
			var result = controller.Index() as ViewResult;
			Assert.IsNotNull(result);
		}
		[TestMethod]
		public void IndexPageReturnsTheRightView() {
			var controller = new HomeController();
			var result = controller.Index() as ViewResult;

			Assert.AreEqual("Index", result.ViewName);
		}

	}
}
