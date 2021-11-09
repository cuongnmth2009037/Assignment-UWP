using System;
using System.Collections.Generic;
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
    public sealed partial class MenuBarDemo : Page
    {
        public MenuBarDemo()
        {
            this.InitializeComponent();
        }

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            var menuFlyoutItem = sender as MenuFlyoutItem;
            switch (menuFlyoutItem.Tag)
            {
                case "new":
                    MyMainContent.Navigate(typeof(Pages.LoginPage));
                    break;
                case "open":
                    MyMainContent.Navigate(typeof(Pages.RegisterPage));
                    break;
                case "save":
                    MyMainContent.Navigate(typeof(Pages.ListSong));
                    break;
                case "exit":
                    MyMainContent.Navigate(typeof(Pages.CreateSong));
                    break;
            }
        }
    }
}
