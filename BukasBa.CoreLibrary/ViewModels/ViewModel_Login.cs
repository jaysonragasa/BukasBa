using BukasBa.CoreLibrary.DataSource.Interfaces;
using BukasBa.CoreLibrary.Models.UI;
using GalaSoft.MvvmLight.Command;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BukasBa.CoreLibrary.ViewModels
{
    public class ViewModel_Login : VMBase
    {
        #region events
        public EventHandler OnRegistration;
        public EventHandler OnLoginSuccess;
        public EventHandler OnGuest;
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
            if (this.AuthDetails.IsStore)
            {
                var result = await this._data.AuthService.LoginAsync(this.AuthDetails);

                if (result.IsOk)
                {
                    _data.Token = result.Attributes["token"];
                    _data.UserId = result.Attributes["localid"];

                    //this.Nav.ShowRoot("main");
                    OnLoginSuccess?.Invoke(this, null);
                }
                else
                {
                    string errmsg = result.Message;

                    if (errmsg == "INVALID_PASSWORD") 
                        await this.Dialog.ShowMessage("Invalid Password.", "Login", "ok", null);
                    else if (errmsg == "EMAIL_NOT_FOUND") 
                        await this.Dialog.ShowMessage("Email not registered.", "Login", "ok", null);
                    else if (errmsg == "INVALID_EMAIL")
                        await this.Dialog.ShowMessage("Email not in valid format.", "Login", "ok", null);
                    else if (errmsg.Contains("TOO_MANY_ATTEMPTS_TRY_LATER"))
                        await this.Dialog.ShowMessage("Too many unsuccessful login attempts. Please try again later.", "Login", "ok", null);
                    else 
                        await this.Dialog.ShowMessage("Unable to login. Please try again", "Login", "ok", null);
                }
            }
            else
            {
                //this.Nav.ShowRoot("main");
                OnGuest?.Invoke(this, null);
            }
        }

        void Command_Register_Click()
        {
            //this.Nav.NavigateTo(Enums.Enum_Pages.STOREOWNER_REGISTRATION);
            OnRegistration?.Invoke(this, null);
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