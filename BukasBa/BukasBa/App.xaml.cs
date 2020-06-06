using BukasBa.UI.Pages.Customer;
using Xamarin.Forms;

namespace BukasBa
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new StoreLists();
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
