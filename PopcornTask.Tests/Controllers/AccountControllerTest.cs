using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PopcornTask.Controllers;
using PopcornTask.Models;
using PopcornTask.Shared;

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
			TestInitialize.CreateTestUser(User.Username, User.Password);

			SystemUser resultUser;
			var result = controller.validateUserData(User, out resultUser);

			TestInitialize.DeleteTestUser(User.Username);

			Assert.IsTrue(result);
			Assert.AreEqual(User.Username.Trim(), resultUser.Username.Trim());
		}
		[TestMethod]
		public void LoginFailsWhenSuppliedInvalidUserData() {
			var controller = new AccountController();
			string username = "test";

			TestInitialize.CreateTestUser(username, "test1");

			var WrongUser = new SystemUser();
			WrongUser.Username = "testx";
			WrongUser.Password = "textxx";

			SystemUser resultUser;

			var result = controller.validateUserData(WrongUser, out resultUser);

			TestInitialize.DeleteTestUser(username);

			Assert.IsFalse(result);
			Assert.IsNull(resultUser);
		}
		[TestMethod]
		public void LoginFailsWhenSuppliedRightUsernameAndInvalidPassword() {
			var controller = new AccountController();
			string username = "test";

			TestInitialize.CreateTestUser(username, "test1");

			var WrongUser = new SystemUser();
			WrongUser.Username = username;
			WrongUser.Password = "textxx";

			SystemUser resultUser;

			var result = controller.validateUserData(WrongUser, out resultUser);

			TestInitialize.DeleteTestUser(username);

			Assert.IsFalse(result);
			Assert.IsNull(resultUser);
		}
	}
}
