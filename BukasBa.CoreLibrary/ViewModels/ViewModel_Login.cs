using BukasBa.CoreLibrary.DataSource.Interfaces;
using BukasBa.CoreLibrary.Models.UI;
using GalaSoft.MvvmLight.Command;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BukasBa.CoreLibrary.ViewModels
{
    public class ViewModel_Login : VMBase
    {
        #region events

        #endregion

        #region vars

        #endregion

        #region properties
        private Model_AuthDetails _authDetails = new Model_AuthDetails();
        public Model_AuthDetails AuthDetails
        {
            get { return _authDetails; }
            set { Set(nameof(AuthDetails), ref _authDetails, value); }
        }

        private bool _rememberMe = false;
        public bool RememberMe
        {
            get { return _rememberMe; }
            set { Set(nameof(RememberMe), ref _rememberMe, value); }
        }
        #endregion

        #region commands
        public ICommand Command_Login { get; set; }
        public ICommand Command_Register { get; set; }
        #endregion

        #region ctors
        public ViewModel_Login(IDataLocator dataLocator)
        {
            InitCommands();

            this._data = dataLocator;
        }
        #endregion

        #region command methods
        async void Command_Login_Click()
        {
            var result = await this._data.AuthService.LoginAsync(this.AuthDetails);

            if(result.IsOk)
            {

            }
            else
            {

            }
        }

        void Command_Register_Click()
        {

        }
        #endregion

        #region methods
        public override void InitCommands()
        {
            base.InitCommands();

            if (Command_Login == null) Command_Login = new RelayCommand(Command_Login_Click);
            if (Command_Register == null) Command_Register = new RelayCommand(Command_Register_Click);
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