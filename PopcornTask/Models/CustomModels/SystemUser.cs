using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PopcornTask.Shared;

namespace PopcornTask.Models {
	[MetadataType(typeof(SystemUserViewModel))]
	public partial class SystemUser {
		public Decimal GetTotalCost() {
			var db = new PopcornDataEntities();
			var Order = db.Orders.FirstOrDefault(o => o.Status == (int)OrderStatus.Open && o.FK_UserId == Id);
			if(Order == null) return 0;

			var total = Order.OrderItems.Sum(oi => oi.Popcorn.Discount.HasValue ? (Convert.ToDecimal(oi.Quantity) * oi.Popcorn.Discount) : (Convert.ToDecimal(oi.Quantity) * oi.Popcorn.Price));
			db.Dispose();
			return total.Value;
		}
		public int GetOrderCount() {
			var db = new PopcornDataEntities();
			var Order = db.Orders.FirstOrDefault(o => o.Status == (int)OrderStatus.Open && o.FK_UserId == Id);
			if(Order == null) return 0;

			var total = Order.OrderItems.Sum(oi => oi.Quantity);
			db.Dispose();
			return total;
		}
	}
}