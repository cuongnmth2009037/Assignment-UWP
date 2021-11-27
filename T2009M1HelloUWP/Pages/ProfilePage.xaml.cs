using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using T2009M1HelloUWP.Service;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace T2009M1HelloUWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProfilePage : Page
    {
        private AccountService accountService = new AccountService();
        public ProfilePage()
        {
            this.InitializeComponent();
            this.Loaded += ProfilePage_Loaded;
        }

        private async void ProfilePage_Loaded(object sender, RoutedEventArgs e)
        {           

            /* if (App.CurrentAccount == null)
             {
                 ContentDialog contentDialog = new ContentDialog();
                 contentDialog.Title = "Login required";
                 contentDialog.Content = $"Please login continue!";
                 contentDialog.PrimaryButtonText = "Go it!";
                 await contentDialog.ShowAsync();
                 Frame.Navigate(typeof(Pages.LoginPage));
             }
             else
             {
                 Email.Text = App.CurrentAccount.email;
                 FullName.Text = App.CurrentAccount.firstName + " " + App.CurrentAccount.lastName;
             }*/
            var account =  await accountService.GetInformationAsync();
            if (account == null)
            {
                ContentDialog contentDialog = new ContentDialog
                {
                    Title = "Login required",
                    Content = $"Please login continue!",
                    PrimaryButtonText = "Go it!"
                };
                await contentDialog.ShowAsync();
                Frame.Navigate(typeof(Pages.LoginPage));
            }
            else
            {
               Avatar.ImageSource = new BitmapImage(new Uri(account.avatar));
               Avatar.Stretch = Stretch.UniformToFill;
               FullName.Text = account.lastName + " " + account.firstName;
               Phone.Text = account.phone;
               Address.Text = account.address;
               Birthday.Text = account.birthday;
               Email.Text = account.email;                                         
            }
        }
    }
}
