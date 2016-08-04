using System;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TryAgain
{
	public class AllMap : Map
	{

		public static Map map = new Map();
		public AllMap()
		{
			
			MapSpan.FromCenterAndRadius(
				new Position(0, 0), Distance.FromMiles(10));
			this.IsShowingUser = true;
			this.HeightRequest = 100;
			this.WidthRequest = 960;
			this.VerticalOptions = LayoutOptions.FillAndExpand;
			map = this;
		}
	}
}


