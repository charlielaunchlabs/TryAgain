using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TryAgain
{
	public class Master : MasterDetailPage
	{

		public static ListView lista { get; set; }
		public Master()
		{
			ContentView menuLabel = new ContentView
			{
				Padding = new Thickness(10, 36, 0, 5),
				Content = new Label
				{
					TextColor = Color.Black,
					Text = "--- Saved ---",

				}
			};

			lista = new ListView();
			lista.ItemTemplate = new DataTemplate(typeof(CustomListChuchu));
			var all = App.DAUtil.AllUser();

			var oc = new ObservableCollection<Lugars>(all);

			lista.ItemsSource = oc;
			lista.BindingContext = oc;
			lista.SeparatorVisibility = Xamarin.Forms.SeparatorVisibility.None;

			this.Master = new ContentPage
			{
				 
				Title = "Saved",
				Content = new StackLayout
				{
					Children = { menuLabel,lista}
				},
			};

			lista.ItemTapped += (sender, e) =>
			{
				Lugars item = (Lugars)e.Item;
				//navigate to nxt map
				var positio = new Position(item.Lat, item.Lng);
				AllMap.map.Pins.Add(new Pin
				{
					Type = PinType.Place,
					Position = positio,
					Label = item.Name,
					Address = "sds"
				});
				AllMap.map.MoveToRegion(MapSpan.FromCenterAndRadius(positio, Distance.FromMiles(15)));

				//Detail = new NavigationPage(new SelectedMap(item));
				((ListView)sender).SelectedItem = null;
				this.IsPresented = false;
			
			};

			Detail = new NavigationPage(new MainPage());

		}
	}

	class CustomListChuchu : ViewCell
	{
		public CustomListChuchu()
		{
			this.Height = 100;
			Label namelbl = new Label
			{
				TextColor = Color.Accent,
				FontSize = 10,
				FontAttributes = Xamarin.Forms.FontAttributes.Bold,
			};
			namelbl.SetBinding(Label.TextProperty, "Name");

			Label latlbl = new Label
			{
				TextColor = Color.Accent,
				FontSize = 10,
				FontAttributes = Xamarin.Forms.FontAttributes.Italic,
			};
			latlbl.SetBinding(Label.TextProperty, "Lat");

			Label lnglbl = new Label
			{
				TextColor = Color.Accent,
				FontSize = 10,
				FontAttributes = Xamarin.Forms.FontAttributes.Italic,
			};
			lnglbl.SetBinding(Label.TextProperty, "Lng");



			StackLayout firstStack = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = { latlbl, lnglbl }
			};

			StackLayout secondstack = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = { namelbl, firstStack }

			};


			StackLayout main = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = { secondstack }

			};
			StackLayout x = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = { main }

			};

			View = x;
		}


	}
}


