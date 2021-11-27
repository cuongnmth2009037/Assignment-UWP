using Photos.Entities;
using Photos.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

namespace Photos.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListPhoto : Page
    {
        private PostPhotoService postPhotoService = new PostPhotoService();
        public ListPhoto()
        {
            this.InitializeComponent();
            this.Loaded += ListPhoto_LoadedAsync;
        }

        private async void ListPhoto_LoadedAsync(object sender, RoutedEventArgs e)
        {
            var listPhoto = await postPhotoService.GetPhotoAsync();
            ListViewPhoto.ItemsSource = listPhoto;
        }

        private void ListViewPhoto_Tapped(object sender, TappedRoutedEventArgs e)
        {
           
        }
    }
}
