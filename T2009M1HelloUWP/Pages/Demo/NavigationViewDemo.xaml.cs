using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class NavigationViewDemo : Page
    {        
        private bool IsAdmin = false;
        public NavigationViewDemo()
        {
            IsAdmin = App.CurrentAccount != null && App.CurrentAccount.role == 99;
            this.InitializeComponent();
            this.contentFrame.Navigate(typeof(Pages.ProfilePage));           
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected) /*Click nut setting*/
            {
                Debug.WriteLine("Select setting.");
            }
            var navigationViewItem = args.SelectedItem as NavigationViewItem;
            switch (navigationViewItem.Tag)
            {              
                case "Register":
                    this.contentFrame.Navigate(typeof(Pages.RegisterPage));
                    break;
                case "Profile":
                    this.contentFrame.Navigate(typeof(Pages.ProfilePage));
                    break;
                case "ListSong":
                    this.contentFrame.Navigate(typeof(Pages.ListSong));
                    break;
                case "MySong":
                    this.contentFrame.Navigate(typeof(Pages.MySong));
                    break;
                case "CreateSong":
                    this.contentFrame.Navigate(typeof(Pages.CreateSong));
                    break;
            }
        }

        private async void LogOut(object sender, TappedRoutedEventArgs e)
        {
            StorageFile filed = await ApplicationData.Current.LocalFolder.GetFileAsync("music.txt");
            if (filed != null)
            {
                await filed.DeleteAsync();
                Frame.Navigate(typeof(Pages.LoginPage));
            }

        }
    }
}
