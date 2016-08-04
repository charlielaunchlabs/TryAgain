using System;

using Xamarin.Forms;

namespace TryAgain
{
	public class Form : StackLayout
	{
		public Form()
		{

			//PlacesAutoComplete autoComplete = new PlacesAutoComplete(false) { ApiToUse = PlacesAutoComplete.PlacesApi.Native };
			//autoComplete.SetBinding(PlacesAutoComplete.PlaceSelectedCommandProperty, "PlaceSelectedCommand");
			MainPage.autoComplete.SetBinding(PlacesAutoComplete.PlaceSelectedCommandProperty, "PlaceSelectedCommand");
			this.Orientation = StackOrientation.Vertical;
			this.HeightRequest = 100;
			this.WidthRequest = 200;
			this.BackgroundColor = Color.Transparent;
			this.Children.Add(MainPage.autoComplete);
			this.Children.Add(MainPage.button);

		}
	}
}


