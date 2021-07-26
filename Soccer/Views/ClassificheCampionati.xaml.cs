using Soccer.Resources;
using Soccer.ViewModels;
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
    public partial class ClassificheCampionati : ContentPage
    {
        public ClassificheCampionati()
        {
            InitializeComponent();
            BindingContext = new ClassificheCampViewModels(Navigation);
            Shell.SetTabBarIsVisible(this, false);

        }

        
    }
}