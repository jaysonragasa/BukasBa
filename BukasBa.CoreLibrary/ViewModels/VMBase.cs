using BukasBa.CoreLibrary.DataSource.Interfaces;
using BukasBa.CoreLibrary.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System.Windows.Input;

namespace BukasBa.CoreLibrary.ViewModels
{
    public class VMBase : ViewModelBase
    {
        #region events

        #endregion

        #region vars
        public IDataLocator _data;
        #endregion

        #region properties
        public IDialog Dialog { get; set; } = SimpleIoc.Default.GetInstance<IDialog>();
        public INavigation Nav { get; set; } = SimpleIoc.Default.GetInstance<INavigation>();

        private bool _ShowMessageDialog = false;
        public bool ShowMessageDialog
        {
            get { return _ShowMessageDialog; }
            set { Set(nameof(ShowMessageDialog), ref _ShowMessageDialog, value); }
        }

        private string _dialogTitle = null;
        public string DialogTitle
        {
            get { return _dialogTitle; }
            set { Set(nameof(DialogTitle), ref _dialogTitle, value); }
        }

        private string _dialogMessage = null;
        public string DialogMessage
        {
            get { return _dialogMessage; }
            set { Set(nameof(DialogMessage), ref _dialogMessage, value); }
        }

        private bool _IsBusy = false;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set { Set(nameof(IsBusy), ref _IsBusy, value); }
        }
        #endregion

        #region commands
        public ICommand Command_DialogOk { get; set; }
        public ICommand Command_TapBackdropToClose { get; set; }
        #endregion

        #region command methods
        void Command_DialogOk_Click()
        {

        }
        #endregion

        #region methods
        public virtual void InitCommands()
        {
            if (Command_DialogOk == null) Command_DialogOk = new RelayCommand(Command_DialogOk_Click);
        }

        public void ShowDialog(string title, string message)
        {
            this.DialogTitle = title;
            this.DialogMessage = message;
            this.ShowMessageDialog = true;
        }

        public void HideDialog()
        {
            this.DialogTitle = null;
            this.DialogMessage = null;
            this.ShowMessageDialog = false;
        }
        #endregion
    }
}