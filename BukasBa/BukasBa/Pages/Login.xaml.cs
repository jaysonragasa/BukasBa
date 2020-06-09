using BukasBa.CoreLibrary.Services;
using BukasBa.CoreLibrary.ViewModels;
using BukasBa.UI.Pages.Store;
using GalaSoft.MvvmLight.Ioc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BukasBa.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();

            ((ViewModelLocator)this.BindingContext).Login.OnRegistration += (s, e) =>
            {
                this.Navigation.PushModalAsync(new StoreOwnerRegistration());
            };
            ((ViewModelLocator)this.BindingContext).Login.OnLoginSuccess += (s, e) =>
            {
                ((App)Application.Current).MainPage = new StoreShell();

                var dlg = SimpleIoc.Default.GetInstance<IDialog>();
                dlg.PageHost = ((App)Application.Current).MainPage;
            };
            ((ViewModelLocator)this.BindingContext).Login.OnGuest += (s, e) =>
            {
                ((App)Application.Current).MainPage = new AppShell();

                var dlg = SimpleIoc.Default.GetInstance<IDialog>();
                dlg.PageHost = ((App)Application.Current).MainPage;
            };
        }
    }
}