using Xamarin.Forms;

namespace Soccer.Views
{
    public partial class FlyoutHeader : ContentView
    {
        public FlyoutHeader()
        {
            InitializeComponent();
            Shell.SetTabBarIsVisible(this, false);
        }
    }
}
