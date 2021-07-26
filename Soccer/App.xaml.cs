using Soccer.Controls;
using Soccer.Models;
using Soccer.Pages;
using Soccer.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Soccer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new Anteprimaa());

            DatabaseUser dbu = new DatabaseUser();
            Task<Utente> task = Task.Run<Utente>(async () => await dbu.getUserMantain());
            var user = task.Result;
            if (user != null)
            {
                Preferences.Set("Nome", user.Nome);
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                MainPage = new NavigationPage(new Anteprima());
            }

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
