using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TryAgain
{
	public class TableAccess
	{
		SQLite.Net.SQLiteConnection db;
		public TableAccess()
		{
			db = DependencyService.Get<SQLConnect>().GetConnection();
			db.CreateTable<Lugars>();
		}
		public int AddUser(Lugars i)
		{
			return db.Insert(i);
		}
		public int UpdateUser(Lugars i)
		{
			return db.Update(i);
		}
		public List<Lugars> AllUser()
		{
			return db.Query<Lugars>("Select * From [Lugars]");
		}
		public int DeleteUser(Lugars i)
		{
			return db.Delete(i);
		}
	}
}


