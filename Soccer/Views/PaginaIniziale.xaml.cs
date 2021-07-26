using Soccer.Controls;
using Soccer.ViewModels;
using Xamarin.Forms;

namespace Soccer.Views
{
	public partial class PaginaIniziale : ContentPage
	{
		public PaginaIniziale()
		{
			InitializeComponent();
			Shell.SetTabBarIsVisible(this, false);
			DatabaseUser dbu = new DatabaseUser();
			BindingContext = new PaginaInzialeViewModels(Navigation);
			avanti.Source = ImageSource.FromResource("Soccer.Immagini.b1.png");
			indietro.Source = ImageSource.FromResource("Soccer.Immagini.b2.png");
			neww.Source = ImageSource.FromResource("Soccer.Immagini.newtickets.png");
			reload.Source = ImageSource.FromResource("Soccer.Immagini.reload.png");
			storico.Source = ImageSource.FromResource("Soccer.Immagini.storico.png");
			ladder.Source = ImageSource.FromResource("Soccer.Immagini.ladder.png");
			lader.Source = ImageSource.FromResource("Soccer.Immagini.lader.png");
			tools.Source = ImageSource.FromResource("Soccer.Immagini.tools.png");
			connectionerror.Source = ImageSource.FromResource("Soccer.Immagini.connectionerror.png");

			switch (Device.RuntimePlatform)
			{
				case Device.UWP:
					neww.WidthRequest = 120;
					reload.WidthRequest = 120;
					storico.WidthRequest = 120;
					ladder.WidthRequest = 120;
					lader.WidthRequest = 120;
					tools.WidthRequest = 120;
					break;
			}


		}


	}
}

