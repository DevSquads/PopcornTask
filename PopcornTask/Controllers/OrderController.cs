using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PopcornTask.Models;
using PopcornTask.Shared;

namespace PopcornTask.Controllers
{
    public class OrderController : Controller
    {
		private PopcornTask.Models.PopcornDataEntities db = new Models.PopcornDataEntities();
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
		public void deleteCurrentOrderOfUser(int UserId) {
			var User = db.SystemUsers.FirstOrDefault(u => u.Id == UserId);
			var Order = User.Orders.FirstOrDefault(o => o.Status == (int)OrderStatus.Open);

			if(Order == null) return;

			db.OrderItems.RemoveRange(Order.OrderItems);
			db.Orders.Remove(Order);

			db.SaveChanges();
		}
		public void addOrderToUser(int UserId, int popcornId) {
			var User = db.SystemUsers.FirstOrDefault(u => u.Id == UserId);
			var UserCurrentOrder = User.Orders.FirstOrDefault(o => o.Status == (int)OrderStatus.Open);
			if(UserCurrentOrder == null) {
				var newOrder = new Order();
				newOrder.Status = (int)OrderStatus.Open;
				User.Orders.Add(newOrder);
				UserCurrentOrder = newOrder;
			}
			var OrderItem = UserCurrentOrder.OrderItems.FirstOrDefault(oi => oi.FK_PopcornId == popcornId);
			if(OrderItem == null) {
				var newOrderItem = new OrderItem();
				newOrderItem.FK_PopcornId = popcornId;
				newOrderItem.Quantity = 0;
				UserCurrentOrder.OrderItems.Add(newOrderItem);
				OrderItem = newOrderItem;
			}

			OrderItem.Quantity += 1;
			db.SaveChanges();
		}
		[HttpPost]
		public void AddOrder(int popcornId) {
			addOrderToUser(SessionContainer.User.Id, popcornId);
		}

		public JsonResult GetCurrentOrderValues() {
			return Json(
				new {
					total_cost = SessionContainer.User.GetTotalCost(),
					order_count = SessionContainer.User.GetOrderCount()
				},
				JsonRequestBehavior.AllowGet
			);
		}
	}
}