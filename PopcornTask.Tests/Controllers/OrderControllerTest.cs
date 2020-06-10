using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PopcornTask.Controllers;

namespace PopcornTask.Tests.Controllers {
	[TestClass]
	public class OrderControllerTest {
		[TestMethod]
		public void OrdersAddedCorrectly() {
			int UserId = TestInitialize.CreateTestUser("test", "test");
			int PopcornId = TestInitialize.GetPopcornNumber(2);

			var controller = new OrderController();
			controller.addOrderToUser(UserId, PopcornId);
			controller.addOrderToUser(UserId, PopcornId);

			PopcornId = TestInitialize.GetPopcornNumber(1);

			controller.addOrderToUser(UserId, PopcornId);

			var db = new Models.PopcornDataEntities();
			var popcornCount = db.SystemUsers.FirstOrDefault(u => u.Id == UserId).GetOrderCount();

			controller.deleteCurrentOrderOfUser(UserId);

			TestInitialize.DeleteTestUser("test");

			Assert.AreEqual(3, popcornCount);
		}
		[TestMethod]
		public void TotalCostIsCalculatedCorrectly() {
			int UserId = TestInitialize.CreateTestUser("test", "test");
			int PopcornId = TestInitialize.GetPopcornNumber(2);
			var db = new Models.PopcornDataEntities();

			var ActualCost = Convert.ToDecimal(0.0);

			var controller = new OrderController();
			controller.addOrderToUser(UserId, PopcornId);
			controller.addOrderToUser(UserId, PopcornId);

			var Popcorn = db.Popcorns.FirstOrDefault(p => p.Id == PopcornId);

			ActualCost += Popcorn.Discount.HasValue ? (2 * Popcorn.Discount.Value) : (2 * Popcorn.Price); 

			PopcornId = TestInitialize.GetPopcornNumber(1);

			Popcorn = db.Popcorns.FirstOrDefault(p => p.Id == PopcornId);

			controller.addOrderToUser(UserId, PopcornId);

			ActualCost += Popcorn.Discount.HasValue ? Popcorn.Discount.Value : Popcorn.Price;

			var FoundCost = db.SystemUsers.FirstOrDefault(u => u.Id == UserId).GetTotalCost();

			controller.deleteCurrentOrderOfUser(UserId);

			TestInitialize.DeleteTestUser("test");

			Assert.AreEqual(ActualCost, FoundCost);
		}
	}
}
