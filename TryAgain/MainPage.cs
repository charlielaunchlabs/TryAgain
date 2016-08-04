using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TK.CustomMap;
using TK.CustomMap.Api;
using TK.CustomMap.Api.OSM;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TryAgain
{
	public class MainPage : ContentPage
	{
		public static Entry entry = new Entry() { VerticalOptions = LayoutOptions.CenterAndExpand };

		public static Button button = new Button() { WidthRequest=150,Text = "Press", VerticalOptions = LayoutOptions.CenterAndExpand ,BackgroundColor=Color.White,HorizontalOptions=LayoutOptions.Center};

		public static PlacesAutoComplete autoComplete = new PlacesAutoComplete(false) { ApiToUse = PlacesAutoComplete.PlacesApi.Google };

	
		Geocoder geo = new Geocoder();

		public MainPage()
		{
			//PlacesAutoComplete autoComplete = new PlacesAutoComplete(true) { ApiToUse = PlacesAutoComplete.PlacesApi.Google };
			autoComplete.SetBinding(PlacesAutoComplete.PlaceSelectedCommandProperty, "PlaceSelectedCommand");

			autoComplete.SetBinding(PlacesAutoComplete.BoundsProperty, "MapRegion");

			Button btn = new Button {Text = "Show",HorizontalOptions=LayoutOptions.CenterAndExpand ,HeightRequest =50,WidthRequest=100,BackgroundColor=Color.Aqua};
			Title = "Map";
			RelativeLayout main = new RelativeLayout();

		
			//var als = App.DAUtil.AllUser();


			//for (int i = 0; i < als.Count;i++) 
			//{
			//	map.Pins.Add(new Pin
			//	{
			//		Type = PinType.Place,
			//		Position = new Position(als[i].Lat,als[i].Lng),
			//		Label = als[i].Name,
			//		Address = "sds"
			//	});
			//}

			//map.FitMapRegionToPositions(((System.Collections.Generic.IEnumerable<Xamarin.Forms.Maps.Position>)(IEnumerable)(x)),false);

			var stack = new StackLayout { Spacing = 0 };
			//stack.Children.Add(autoComplete);
			stack.Children.Add(AllMap.map);
			main.Children.Add(stack,
						   Constraint.RelativeToParent((p) => { return p.X; }),
						   Constraint.RelativeToParent((p) => { return p.Y; }),
						   Constraint.RelativeToParent((p) => { return p.Width; }),
						   Constraint.RelativeToParent((p) => { return p.Height; })
						  );


			Form form = new Form();
			form.IsVisible = false;
			main.Children.Add(form,
			                  Constraint.Constant(0),
						  	  Constraint.Constant(0),
			                  Constraint.RelativeToParent((p) => { return p.Width; })

						  ); 
			main.Children.Add(btn,
			                  Constraint.RelativeToParent((p) => { return p.Width /2 - btn.WidthRequest / 2; }),
			                  Constraint.RelativeToParent((p) => { return p.Height - btn.HeightRequest - 10; })
			                 );
			//main.Children.Add(
			//	autoComplete,
			//	Constraint.Constant(0),
			//	Constraint.Constant(0));
			Content = main;


			btn.Clicked +=  (sender, e) =>
			{

				var animation = new Animation(callback: d => form.Rotation = d,
								 start: button.Rotation,
								 end: button.Rotation + 360,
								 easing: Easing.SpringOut);
				animation.Commit(form, "Loop", length: 800);

				form.IsVisible = true;
				btn.IsVisible = false;
			};
			button.Clicked += async (sender, e) =>
			{
				try 
				{

					double lat = 0, lng = 0;
					var approximateLocations = await geo.GetPositionsForAddressAsync(autoComplete._entry.Text);
					foreach (var position in approximateLocations)
					{
						lat = position.Latitude;
						lng = position.Longitude;
						break;
					}

					var positio = new Position(lat, lng);
					AllMap.map.Pins.Add(new Pin
					{
						Type = PinType.Place,
						Position = positio,
						Label = "pin",
						Address = "sds"
					});

					var insert = new Lugars()
					{
						Name = autoComplete._entry.Text,
						Lat = lat,
						Lng = lng
					};

					App.DAUtil.AddUser(insert);
					var all = App.DAUtil.AllUser();
					var oc = new ObservableCollection<Lugars>(all);
					Master.lista.ItemsSource = oc;

					AllMap.map.MoveToRegion(MapSpan.FromCenterAndRadius(positio, Distance.FromMiles(15)));

					var animation = new Animation(callback: d => btn.Rotation = d,
								 start: button.Rotation,
								 end: button.Rotation + 360,
								 easing: Easing.SpringOut);
					
					animation.Commit(btn, "Loop", length: 800);
				
					form.IsVisible = false;
					btn.IsVisible = true;
				}
				catch 
				{
					await DisplayAlert("---","---","OK");
					var animation = new Animation(callback: d => btn.Rotation = d,
								 start: button.Rotation,
								 end: button.Rotation + 360,
								 easing: Easing.SpringOut);
					animation.Commit(btn, "Loop", length: 800);
					form.IsVisible = false;
					btn.IsVisible = true;
				}

			};

		}

	}
}


