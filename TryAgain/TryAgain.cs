using System;
using TK.CustomMap.Api;
using TK.CustomMap.Api.Google;
using Xamarin.Forms;

namespace TryAgain
{
	public class App : Application
	{
		public App()
		{
			GmsPlace.Init("AIzaSyAPG4sE6X99SivTUHCz7FnIi2gzfh1C_U8");
			GmsDirection.Init("AIzaSyCJN3Cd-Sp1a5V5OnkvTR-Gqhx7A3S-b6M");

			MainPage = new NavigationPage(new MainPage());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

