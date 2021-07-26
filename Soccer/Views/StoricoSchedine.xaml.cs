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
    public partial class StoricoSchedine : ContentPage
    {
        public StoricoSchedine()
        {
            InitializeComponent();
            Shell.SetTabBarIsVisible(this, false);
        }
    }
}