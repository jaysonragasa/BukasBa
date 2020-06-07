﻿using BukasBa.UI.Pages;
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
            //MainPage = new CustomerDashboard();
            //MainPage = new Login();
            MainPage = new CustomerRegistration();
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