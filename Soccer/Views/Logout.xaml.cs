using Soccer.Controls;
using Soccer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Soccer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Logout : ContentPage
    {
        public Logout()
        {
            InitializeComponent();
            Shell.SetTabBarIsVisible(this, false);
            DatabaseUser dbu = new DatabaseUser();
            Task<Utente> task = Task.Run<Utente>(async () => await dbu.setMantainUserDisable());
            Application.Current.MainPage = new NavigationPage(new Anteprima());
        }
    }
}