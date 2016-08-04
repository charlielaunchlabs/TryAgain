using System;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TryAgain
{
	public class SelectedMapa : ContentPage
	{
		Lugars selected;

		public SelectedMapa(Lugars item)//useless
		{
			selected = item;
			RelativeLayout main = new RelativeLayout();
			this.Title = selected.Name;


			var goTo = new ToolbarItem
			{
				Text = "  +  ",

				Command = new Command(async () => await Navigation.PushModalAsync(new Master()))
			};
			this.ToolbarItems.Add(goTo);
			var stack = new StackLayout { Spacing = 0 };

			var positio = new Position(selected.Lat, selected.Lng);
			AllMap.map.Pins.Add(new Pin
			{
				Type = PinType.Place,
				Position = positio,
				Label = selected.Name,
				Address = "sds"
			});

			stack.Children.Add(AllMap.map);
			main.Children.Add(stack,
						   Constraint.RelativeToParent((p) => { return p.X; }),
						   Constraint.RelativeToParent((p) => { return p.Y; }),
						   Constraint.RelativeToParent((p) => { return p.Width; }),
						   Constraint.RelativeToParent((p) => { return p.Height; })
						  );

			Content = main;
		}
	}
}


