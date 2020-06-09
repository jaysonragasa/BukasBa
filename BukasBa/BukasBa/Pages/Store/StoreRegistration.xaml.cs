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
            ((ViewModelLocator)this.BindingContext).StoreRegistration.OnCameraTapped += OpenCamera;
            ((ViewModelLocator)this.BindingContext).StoreRegistration.OnImageGalleryTapped += OpenImageGallery;
            ((ViewModelLocator)this.BindingContext).StoreRegistration.OnNewStore += ClearImage;
            ((ViewModelLocator)this.BindingContext).StoreRegistration.OnReloadPicture += ReloadImage;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ((ViewModelLocator)this.BindingContext).StoreRegistration.OnCameraTapped -= OpenCamera;
            ((ViewModelLocator)this.BindingContext).StoreRegistration.OnImageGalleryTapped -= OpenImageGallery;
            ((ViewModelLocator)this.BindingContext).StoreRegistration.OnNewStore -= ClearImage;
            ((ViewModelLocator)this.BindingContext).StoreRegistration.OnReloadPicture -= ReloadImage;
        }

        void ClearImage(object sender, EventArgs e)
        {
            ReloadImage(sender, null);
        }

        void ReloadImage(object sender, string imageurl)
        {
            if (!string.IsNullOrEmpty(imageurl))
            {
                srcImage.Source = ImageSource.FromUri(new Uri(imageurl));
            }
            else
            {
                srcImage.Source = null;
            }
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
                ((ViewModelLocator)this.BindingContext).StoreRegistration.SelectedImagePath = file.Single().Path;
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
                Name = $"IMGT-{DateTime.Now:yyyyMMdd}-{DateTime.Now:HHmmss}.jpg"
            });

            if(file != null)
            {
                this.srcImage.Source = ImageSource.FromFile(file.Path);
                ((ViewModelLocator)this.BindingContext).StoreRegistration.SelectedImagePath = file.Path;
            }
        }
    }
}