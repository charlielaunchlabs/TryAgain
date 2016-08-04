using System;
using SQLite.Net;
using Xamarin.Forms;

namespace TryAgain
{
	public interface SQLConnect
	{

		SQLiteConnection GetConnection();

	}

}


