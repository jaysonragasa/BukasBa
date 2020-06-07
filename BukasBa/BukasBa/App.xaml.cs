using BukasBa.CoreLibrary.Services;
using BukasBa.UI.Pages;
using BukasBa.UI.Pages.Customer;
using BukasBa.UI.Pages.Store;
using BukasBa.UI.Services;
using GalaSoft.MvvmLight.Ioc;
using Xamarin.Forms;

namespace BukasBa
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SimpleIoc.Default.Register<IDialog, DialogService>();

            //MainPage = new StoreRegistration();
            //MainPage = new StoreLists();
            //MainPage = new CustomerDashboard();
            //MainPage = new Login();
            //MainPage = new CustomerRegistration();
            //MainPage = new StoreOwnerRegistration();
            MainPage = new StoreDashboard();

            var dlg = SimpleIoc.Default.GetInstance<IDialog>();
            dlg.PageHost = MainPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
