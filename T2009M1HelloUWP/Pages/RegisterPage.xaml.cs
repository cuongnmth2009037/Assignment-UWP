using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using T2009M1HelloUWP.Entities;
using T2009M1HelloUWP.Utils;
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

namespace T2009M1HelloUWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            this.InitializeComponent();
        }

        private int choosedGender = 1;
        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pages.LoginPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var gender = choosedGender;
            var birthday = datePicker.SelectedDate.Value.ToString("yyyy-MM-dd");
            var email = Email.Text;
            var firstname = firstName.Text;
            var lastname = lastName.Text;
            var address = Address.Text;
            var phone = Phone.Text;
            Debug.WriteLine($"Selected gender: {gender}, FirstName: {firstname}, LastName: {lastname} Birthday: {birthday}, Email: {email}, Address: {address}, Phone: {phone}");
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            var currenTag = radioButton.Tag;
            switch (currenTag)
            {
                case "Male":
                    choosedGender = 1;
                    break;
                case "Female":
                    choosedGender = 0;
                    break;
                case "Other":
                    choosedGender = 2;
                    break;
            }
        }
    }
}
