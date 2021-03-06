﻿using BukasBa.CoreLibrary.Services;
using BukasBa.CoreLibrary.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BukasBa.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            ((ViewModelLocator)this.BindingContext).Shell.OnLogin += (s, o) =>
            {
                ((App)Application.Current).MainPage = ((App)Application.Current).Login;
            };
        }
    }
}