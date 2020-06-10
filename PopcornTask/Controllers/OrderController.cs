using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PopcornTask.Models;
using PopcornTask.Shared;

namespace PopcornTask.Controllers
{
    public class OrderController : BaseController
    {
		private PopcornTask.Models.PopcornDataEntities db = new Models.PopcornDataEntities();
        // GET: Order
        public ActionResult Index()
        {
			List<OrderItem> OrderItems;
			var Order = db.Orders.FirstOrDefault(o => o.Status == (int)OrderStatus.Open && o.FK_UserId == SessionContainer.User.Id);
			if(Order == null) OrderItems = new List<OrderItem>();
			else {
				OrderItems = Order.OrderItems.ToList();
			}
			return View(OrderItems);
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
		public void DeleteOrderItem(int orderItemId) {
			var orderItem = db.OrderItems.FirstOrDefault(oi => oi.Id == orderItemId);
			if(orderItem == null) return;

			db.OrderItems.Remove(orderItem);
			db.SaveChanges();
		}
		public void DeleteOrder() {
			deleteCurrentOrderOfUser(SessionContainer.User.Id);
		}
		public JsonResult OrderItemPlusOne(int orderItemId) {
			var OrderItem = db.OrderItems.FirstOrDefault(oi => oi.Id == orderItemId);
			Decimal total;
			int count;
			if(OrderItem == null) {
				total = 0;
				count = 0;
			} else {
				OrderItem.Quantity += 1;
				count = OrderItem.Quantity;
				total = (OrderItem.Popcorn.Discount.HasValue ? (Convert.ToDecimal(OrderItem.Quantity) * OrderItem.Popcorn.Discount) : (Convert.ToDecimal(OrderItem.Quantity) * OrderItem.Popcorn.Price)).Value;

				db.SaveChanges();
			}

			return Json(
				new {
					total = total,
					count = count
				},
				JsonRequestBehavior.AllowGet
			);
		}
		public JsonResult OrderItemMinusOne(int orderItemId) {
			var OrderItem = db.OrderItems.FirstOrDefault(oi => oi.Id == orderItemId);
			Decimal total;
			int count;
			if(OrderItem == null) {
				total = 0;
				count = 0;
			} else {
				if(OrderItem.Quantity > 1) OrderItem.Quantity -= 1;

				count = OrderItem.Quantity;
				total = (OrderItem.Popcorn.Discount.HasValue ? (Convert.ToDecimal(OrderItem.Quantity) * OrderItem.Popcorn.Discount) : (Convert.ToDecimal(OrderItem.Quantity) * OrderItem.Popcorn.Price)).Value;

				db.SaveChanges();
			}

			return Json(
				new {
					total = total,
					count = count
				},
				JsonRequestBehavior.AllowGet
			);
		}
	}
}