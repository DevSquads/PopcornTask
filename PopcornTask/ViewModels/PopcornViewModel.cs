using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PopcornTask.Models {
	public class PopcornViewModel {
		[DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
		public decimal Price { get; set; }
		[DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
		public Nullable<decimal> Discount { get; set; }
	}
}