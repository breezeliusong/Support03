using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Support03
{
    public sealed partial class ContentDialogExample : ContentDialog
    {
        private ContentDialogButtonClickEventArgs ar;
        public ContentDialogExample()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //args.Cancel = true;
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //args.Cancel = false;
        }

        private async void OpenImage_Click(object sender, TappedRoutedEventArgs e)
        {
            FileOpenPicker filePicker = new FileOpenPicker();
            filePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            filePicker.ViewMode = PickerViewMode.Thumbnail;
            filePicker.FileTypeFilter.Add(".png");
            StorageFile storageFile= await filePicker.PickSingleFileAsync();
            var stream = await storageFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
            var bitmapImage = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
            await bitmapImage.SetSourceAsync(stream);

            var decoder = await Windows.Graphics.Imaging.BitmapDecoder.CreateAsync(stream);
            img.Source = bitmapImage;
        }
    }
}
