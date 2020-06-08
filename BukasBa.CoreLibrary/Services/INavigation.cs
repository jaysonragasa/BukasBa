using BukasBa.CoreLibrary.Enums;
using System;

namespace BukasBa.CoreLibrary.Services
{
    public interface INavigation
    {
        void RegisterPages(Enum_Pages page, Type pageType);
        void GoBack();
        void NavigateTo(Enum_Pages page, string query = null);
        void ShowRoot(string rout, string query = null);
    }
}