using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Soccer.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            var view = ApplicationView.GetForCurrentView();
            if (view.IsFullScreenMode)//example toggle button
            {
                //view.ExitFullScreenMode();
            }
            else
            {
                view.TryEnterFullScreenMode();
            }

            LoadApplication(new Soccer.App());
            Window.Current.CoreWindow.SizeChanged += UpdateUI;

        }
        public void UpdateUI(CoreWindow sender, WindowSizeChangedEventArgs e)
        {
            var view = ApplicationView.GetForCurrentView();
            if (view.IsFullScreenMode)//example toggle button
            {
                //view.ExitFullScreenMode();
            }
            else
            {
                view.TryEnterFullScreenMode();
            }
        }
    }
}
