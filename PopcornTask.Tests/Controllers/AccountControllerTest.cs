using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PopcornTask.Controllers;
using PopcornTask.Models;

namespace PopcornTask.Tests.Controllers {
	[TestClass]
	public class AccountControllerTest {
		[TestMethod]
		public void LoginActionExists() {
			using(new FakeHttpContext.FakeHttpContext()) {
				var controller = new AccountController();
				var result = controller.Login() as ViewResult;
				Assert.IsNotNull(result);
			}
		}
		[TestMethod]
		public void LoginPageReturnsTheRightView() {
			using(new FakeHttpContext.FakeHttpContext()) {
				var controller = new AccountController();
				var result = controller.Login() as ViewResult;

				Assert.AreEqual("Login", result.ViewName);
			}
		}
		[TestMethod]
		public void LoginAuthenticatesWhenSuppliedValidUserData() {
			var controller = new AccountController();
			SystemUser User = new SystemUser();
			User.Username = "test";
			User.Password = "test1";

			var dbContext = new PopcornDataEntities();
			dbContext.SystemUsers.Add(User);
			dbContext.SaveChanges();
			dbContext.Dispose();

			SystemUser resultUser;

			var result = controller.validateUserData(User, out resultUser);

			dbContext = new PopcornDataEntities();
			dbContext.SystemUsers.RemoveRange(dbContext.SystemUsers.Where(u => u.Username == User.Username));
			dbContext.SaveChanges();
			dbContext.Dispose();

			Assert.IsTrue(result);
			Assert.AreEqual(User.Username.Trim(), resultUser.Username.Trim());
		}
		[TestMethod]
		public void LoginFailsWhenSuppliedInvalidUserData() {
			var controller = new AccountController();
			SystemUser User = new SystemUser();
			User.Username = "test";
			User.Password = "test1";

			var dbContext = new PopcornDataEntities();
			dbContext.SystemUsers.Add(User);
			dbContext.SaveChanges();
			dbContext.Dispose();

			var WrongUser = new SystemUser();
			WrongUser.Username = "testx";
			WrongUser.Password = "textxx";

			SystemUser resultUser;

			var result = controller.validateUserData(WrongUser, out resultUser);

			dbContext = new PopcornDataEntities();
			dbContext.SystemUsers.RemoveRange(dbContext.SystemUsers.Where(u => u.Username == User.Username));
			dbContext.SaveChanges();
			dbContext.Dispose();

			Assert.IsFalse(result);
			Assert.IsNull(resultUser);
		}
	}
}
