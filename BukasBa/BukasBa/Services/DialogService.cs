using BukasBa.CoreLibrary.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BukasBa.UI.Services
{
    public class DialogService : IDialog
    {
        public object PageHost { get; set; }

        public async Task ShowError(string message, string title, string buttonText, Action afterHideCallback)
        {
            throw new NotImplementedException();
        }

        public async Task ShowError(Exception error, string title, string buttonText, Action afterHideCallback)
        {
            throw new NotImplementedException();
        }

        public async Task ShowMessage(string message, string title)
        {
            throw new NotImplementedException();
        }

        public async Task ShowMessage(string message, string title, string buttonText, Action afterHideCallback)
        {
            await ((Page)this.PageHost).DisplayAlert(title, message, buttonText);
            afterHideCallback?.Invoke();
        }

        public async Task<bool> ShowMessage(string message, string title, string buttonConfirmText, string buttonCancelText, Action<bool> afterHideCallback)
        {
            bool ret = await ((Page)this.PageHost).DisplayAlert(title, message, buttonConfirmText, buttonCancelText);
            afterHideCallback?.Invoke(ret);

            return ret;
        }

        public async Task ShowMessageBox(string message, string title)
        {
            throw new NotImplementedException();
        }
    }
}