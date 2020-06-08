using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PopcornTask.Tests.Controllers {
	[TestClass]
	class TestInitialize {
		[AssemblyInitialize]
		public static void AssemblyInit(TestContext context) {
			AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\PopcornTask\App_Data")));
		}
	}
}
