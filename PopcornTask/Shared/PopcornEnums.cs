using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopcornTask.Shared {
	public enum Feature {
		None = 0,
		New = 1,
		Extra = 2
	};

	public enum OrderStatus {
		Open = 1,
		Closed = 0
	}
}