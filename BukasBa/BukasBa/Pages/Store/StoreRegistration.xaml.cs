using BukasBa.CoreLibrary.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BukasBa.UI.Pages.Store
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StoreRegistration : ContentPage
    {
        public StoreRegistration()
        {
            InitializeComponent();

            ((ViewModelLocator)this.BindingContext).StoreRegistration.OnCameraTapped += (s, e) => OpenCamera(s, e);
            ((ViewModelLocator)this.BindingContext).StoreRegistration.OnImageGalleryTapped += (s, e) => OpenImageGallery(s, e);
            ((ViewModelLocator)this.BindingContext).StoreRegistration.OnNewStore += (s, e) =>
            {
                srcImage.Source = "";
            };
        }

        async void OpenImageGallery(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable && !CrossMedia.Current.IsTakePhotoSupported)
            {
                // throw some message here.
            }

            var file = await CrossMedia.Current.PickPhotosAsync(new PickMediaOptions()
            {
                CompressionQuality = 80
            });

            if (file.Any())
            {
                this.srcImage.Source = ImageSource.FromFile(file.Single().Path);
                ((ViewModelLocator)this.BindingContext).StoreRegistration.StoreDetails.ImagePath = file.Single().Path;
            }
        }

        async void OpenCamera(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if(!CrossMedia.Current.IsCameraAvailable && !CrossMedia.Current.IsTakePhotoSupported)
            {
                // throw some message here.
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
            {
                Directory = "BukasBa",
                Name = "temp.jpg"
            });

            if(file != null)
            {
                this.srcImage.Source = ImageSource.FromFile(file.Path);
                ((ViewModelLocator)this.BindingContext).StoreRegistration.StoreDetails.ImagePath = file.Path;
            }
        }
    }
}