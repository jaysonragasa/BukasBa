using BukasBa.CoreLibrary.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;

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
            }
        }
    }
}