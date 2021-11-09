using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace T2009M1HelloUWP.Pages.Demo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SplistViewDemo : Page
    {
        public SplistViewDemo()
        {
            this.InitializeComponent();
        }

        private void SymbolIcon_Tapped(object sender, TappedRoutedEventArgs e)
        {

            MySplistView.IsPaneOpen = !MySplistView.IsPaneOpen;
        }

        private void Click_Menu(object sender, TappedRoutedEventArgs e)
        {
            var stackPanel = sender as StackPanel;
            Debug.WriteLine("Click menu" + stackPanel.Tag);
            switch (stackPanel.Tag)
            {
                case "Login":
                    MyContent.Navigate(typeof(Pages.LoginPage));
                    break;
                case "Register":
                    MyContent.Navigate(typeof(Pages.RegisterPage));
                    break;
                case "ListSong":
                    MyContent.Navigate(typeof(Pages.ListSong));
                    break;
                case "CreateSong":
                    MyContent.Navigate(typeof(Pages.CreateSong));
                    break;
            }
        }
    }
}
