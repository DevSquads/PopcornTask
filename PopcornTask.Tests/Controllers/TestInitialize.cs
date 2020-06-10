using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PopcornTask.Models;

namespace PopcornTask.Tests.Controllers {
	[TestClass]
	public class TestInitialize {
		[AssemblyInitialize]
		public static void AssemblyInit(TestContext context) {
			AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\PopcornTask\App_Data")));
		}


		public static int CreateTestUser(string username, string password) {
			SystemUser User = new SystemUser();
			User.Username = username;
			User.Password = password;

			var dbContext = new PopcornDataEntities();

			if(dbContext.SystemUsers.Any(u => u.Username == username && u.Password == password)) {
				int ExUserId = dbContext.SystemUsers.FirstOrDefault(u => u.Username == username && u.Password == password).Id;
				dbContext.Dispose();
				return ExUserId;
			}

			dbContext.SystemUsers.Add(User);
			dbContext.SaveChanges();

			int UserId = dbContext.SystemUsers.FirstOrDefault(u => u.Username == username).Id;

			dbContext.Dispose();

			return UserId;
		}
		public static void DeleteTestUser(string username) {
			var dbContext = new PopcornDataEntities();
			dbContext.SystemUsers.RemoveRange(dbContext.SystemUsers.Where(u => u.Username == username));
			dbContext.SaveChanges();
			dbContext.Dispose();
		}

		public static int GetPopcornNumber(int nummber) {
			var db = new PopcornDataEntities();
			int Id = db.Popcorns.OrderBy(p => p.Id).Skip(nummber - 1).Take(1).FirstOrDefault().Id;
			db.Dispose();
			return Id;
		}
	}
}
