using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PopcornTask;
using PopcornTask.Controllers;
using PopcornTask.Models;
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
		[TestMethod]
		public void IndexActionViewDataContainsPopcorn() {
			var controller = new HomeController();
			var result = controller.Index() as ViewResult;

			Assert.IsNotNull(result.ViewData["Popcorns"]);
		}
		[TestMethod]
		public void IndexActionReturnsListOfPopcorn() {
			var controller = new HomeController();
			var result = controller.Index() as ViewResult;

			Assert.IsInstanceOfType(result.ViewData["Popcorns"], typeof(List<Popcorn>));
		}

	}
}
