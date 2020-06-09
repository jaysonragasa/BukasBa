using BukasBa.CoreLibrary.DataSource.Interfaces;
using GalaSoft.MvvmLight.Command;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BukasBa.CoreLibrary.ViewModels
{
    public class ViewModel_Shell : VMBase
    {
        #region events
        public EventHandler OnLogout;
        public EventHandler OnLogin;
        #endregion

        #region vars

        #endregion

        #region properties

        #endregion

        #region commands
        public ICommand Command_Logout { get; set; }
        public ICommand Command_Login { get; set; }
        #endregion

        #region ctors
        public ViewModel_Shell(IDataLocator dataLocator)
        {
            InitCommands();
            this._data = dataLocator;

            /*
			// used only in UWP & WPF
			// or anything that supports design time updates
			if(base.IsInDesignMode)
			{
				DesignData();
			}
			else
			{
				RuntimeData();
			}
			*/
        }
        #endregion

        #region command methods
        void Command_Logout_Click()
        {
            OnLogout?.Invoke(this, null);
        }

        void Command_Login_Click()
        {
            OnLogin?.Invoke(this, null);
        }
        #endregion

        #region methods
        void InitCommands()
        {
            if (Command_Logout == null) Command_Logout = new RelayCommand(Command_Logout_Click);
            if (Command_Login == null) Command_Login = new RelayCommand(Command_Login_Click);
        }

        void DesignData()
        {

        }

        void RuntimeData()
        {

        }

        public async Task RefreshData()
        {

        }
        #endregion
    }
}