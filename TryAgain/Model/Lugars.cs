using System;
using SQLite.Net.Attributes;
using Xamarin.Forms;

namespace TryAgain
{
	public class Lugars 
	{
		[PrimaryKey, AutoIncrement]
		public long ID { get; set; }
		public string Name { get; set; }
		public double Lat{ get; set; }
		public double Lng { get; set; }
	}
}


