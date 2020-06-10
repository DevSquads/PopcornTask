using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PopcornTask.Models {
	public partial class SystemUserViewModel {
		public int Id { get; set; }
		[Required(ErrorMessage = "Please enter your username!")]
		public string Username { get; set; }
		[Required(ErrorMessage = "Please enter your password!")]
		public string Password { get; set; }
	}
}