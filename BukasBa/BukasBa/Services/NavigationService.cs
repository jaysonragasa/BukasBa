using BukasBa.CoreLibrary.Enums;
using System;
using Xamarin.Forms;

namespace BukasBa.UI.Services
{
    public class NavigationService : BukasBa.CoreLibrary.Services.INavigation
    {
        public void RegisterPages(Enum_Pages page, Type pageType)
        {
            Routing.RegisterRoute(page.ToString(), pageType);
        }

        public void GoBack()
        {
            Shell.Current.Navigation.PopAsync();
        }

        public void NavigateTo(Enum_Pages page, string query = null)
        {
            Shell.Current.GoToAsync(new ShellNavigationState(new Uri($"/{page}?{query}", UriKind.Relative)), true);
        }

        public void ShowRoot(string rout, string query = null)
        {
            Shell.Current.GoToAsync("//" + rout);
        }
    }
}