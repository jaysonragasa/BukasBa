using BukasBa.CoreLibrary.Services;
using BukasBa.CoreLibrary.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BukasBa.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StoreShell : Shell
    {
        public StoreShell()
        {
            InitializeComponent();

            ((ViewModelLocator)this.BindingContext).Shell.OnLogout += (o, s) =>
            {
                ((App)Application.Current).MainPage = ((App)Application.Current).Login;
            };
        }
    }
}