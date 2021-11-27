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
using Windows.Media.Capture;
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
    public sealed partial class CreateSong : Page
    {
        private FileService fileService;
        private AccountService accountService;
        private SongService songService;
        private string _avatarUrl;
        /* private string _accessToken;*/

        public CreateSong()
        {
            this.InitializeComponent();
            this.Loaded += CreateSong_LoadedAsync;
        }

        private async void CreateSong_LoadedAsync(object sender, RoutedEventArgs e)
        {
            fileService = new FileService();
            accountService = new AccountService();
            var account = await accountService.GetInformationAsync();
            if (account == null)
            {
                ContentDialog contentDialog = new ContentDialog();
                contentDialog.Title = "Login required";
                contentDialog.Content = $"Please login continue!";
                contentDialog.PrimaryButtonText = "Go it!";
                await contentDialog.ShowAsync();
                Frame.Navigate(typeof(Pages.LoginPage));
            }
        }

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            songService = new SongService();
            var song = new Song()
            {
                name = Name.Text,
                description = Description.Text,
                author = Author.Text,
                singer = Singer.Text,
                thumbnail = _avatarUrl,
                link = Link.Text,
                message = Message.Text
            };
            var credential = await songService.CreateSongAsync(song);
            if (credential == null)
            {
                ContentDialog contentDialog = new ContentDialog();
                contentDialog.Title = "Action fails";
                contentDialog.Content = $"Upload song fails. Please try again!";
                contentDialog.PrimaryButtonText = "Okie";
                await contentDialog.ShowAsync();      
            }
            else
            {
                ContentDialog contentDialog = new ContentDialog();
                contentDialog.Title = "Action success";
                contentDialog.Content = $"Upload song success!";
                contentDialog.PrimaryButtonText = "Okie";
                await contentDialog.ShowAsync();
            }
        }

        private async void Handle_Camera(object sender, RoutedEventArgs e)
        {
            CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            captureUI.PhotoSettings.CroppedSizeInPixels = new Size(200, 200);
            StorageFile photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);
            if (photo != null)
            {
                progress_image.IsActive = true;
                var result = await fileService.UploadFile(photo);
                if (result != null)
                {
                    _avatarUrl = result;
                    PreviewPhoto.ImageSource = new BitmapImage(new Uri(result));
                    PreviewPhoto.Stretch = Stretch.UniformToFill;
                }
                progress_image.IsActive = false;
            }

        }

        private async void Handle_Click_UploadImage(object sender, RoutedEventArgs e)
        {
            FileOpenPicker filePicker = new FileOpenPicker();
            filePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            filePicker.FileTypeFilter.Add(".jpg");
            filePicker.FileTypeFilter.Add(".jpe");
            filePicker.FileTypeFilter.Add(".png");
            filePicker.ViewMode = PickerViewMode.Thumbnail;
            StorageFile choseFile = await filePicker.PickSingleFileAsync();
            if (choseFile != null)
            {
                progress_image.IsActive = true;
                var result = await fileService.UploadFile(choseFile);
                _avatarUrl = result;
                PreviewPhoto.ImageSource = new BitmapImage(new Uri(result));
                PreviewPhoto.Stretch = Stretch.UniformToFill;
            }
            progress_image.IsActive = false;
        }

        private async void Handle_Click_UploadMp3(object sender, RoutedEventArgs e)
        {
            FileOpenPicker picker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.Downloads
            };
            picker.FileTypeFilter.Add(".mp3");
            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                progress_mp3.IsActive = true;
                var result = await fileService.UploadFile(file);
                Link.Text = result;
            }
            progress_mp3.IsActive = false;
        }      
    }
}

