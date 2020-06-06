using BukasBa.UI.Pages.Store;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BukasBa
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new StoreRegistration();
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
