using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using T2009M1HelloUWP.Entities;
using T2009M1HelloUWP.Service;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace T2009M1HelloUWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        private AccountService accountService = new AccountService();

        public LoginPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size(480, 400);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var loginInformation = new LoginInformation()
            {
                email = Email.Text,
                password = Password.Password.ToString()
            };

            var credential = await accountService.LoginAsync(loginInformation);
            if (credential == null)
            {
                ContentDialog contentDialog = new ContentDialog();
                contentDialog.Title = "Login fails!";
                contentDialog.Content = $"Please check your account or password again!";
                contentDialog.PrimaryButtonText = "Okie";
                await contentDialog.ShowAsync();               
            }
            else
            {
                ContentDialog contentDialog = new ContentDialog();
                contentDialog.Title = "Login success!";
                contentDialog.PrimaryButtonText = "Okie";
                await contentDialog.ShowAsync();
                this.Frame.Navigate(typeof(Pages.Demo.NavigationViewDemo));
            }

        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pages.RegisterPage));
        }
    }
}
