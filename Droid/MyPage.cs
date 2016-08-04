using System;

using Xamarin.Forms;

namespace TryAgain.Droid
{
	public class MyPage : ContentPage
	{
		public MyPage()
		{
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


