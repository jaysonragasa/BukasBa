using GalaSoft.MvvmLight.Views;

namespace BukasBa.CoreLibrary.Services
{
    public interface IDialog : IDialogService
    {
        object PageHost { get; set; }
    }
}