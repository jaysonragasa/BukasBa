using BukasBa.UI.Pages.Customer;
using BukasBa.UI.Pages.Store;

using Xamarin.Forms;

namespace BukasBa
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new StoreRegistration();
            //MainPage = new StoreLists();
            MainPage = new CustomerDashboard();
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
