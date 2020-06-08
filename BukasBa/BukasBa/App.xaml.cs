using BukasBa.CoreLibrary.Services;
using BukasBa.UI;
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

            SimpleIoc.Default.Register<BukasBa.CoreLibrary.Services.INavigation, NavigationService>();
            SimpleIoc.Default.Register<IDialog, DialogService>();

            var nav = (NavigationService)SimpleIoc.Default.GetInstance<BukasBa.CoreLibrary.Services.INavigation>();
            nav.RegisterPages(CoreLibrary.Enums.Enum_Pages.LOGIN, typeof(Login));
            nav.RegisterPages(CoreLibrary.Enums.Enum_Pages.CUSTOMER_FAVORITES, typeof(CustomerDashboard));
            nav.RegisterPages(CoreLibrary.Enums.Enum_Pages.STOREOWNER_DASHBOARD, typeof(StoreDashboard));
            nav.RegisterPages(CoreLibrary.Enums.Enum_Pages.STOREOWNER_REGISTRATION, typeof(StoreOwnerRegistration));
            nav.RegisterPages(CoreLibrary.Enums.Enum_Pages.STOREOWNER_STOREREGISTRATION, typeof(StoreRegistration));
            nav.RegisterPages(CoreLibrary.Enums.Enum_Pages.STORE_LIST, typeof(StoreLists));

            //MainPage = new StoreRegistration();
            //MainPage = new StoreLists();
            //MainPage = new CustomerDashboard();
            //MainPage = new Login();
            //MainPage = new CustomerRegistration();
            //MainPage = new StoreOwnerRegistration();
            //MainPage = new StoreDashboard();

            MainPage = new AppShell();

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
