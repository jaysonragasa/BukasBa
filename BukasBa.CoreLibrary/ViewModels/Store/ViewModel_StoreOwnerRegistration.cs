using BukasBa.CoreLibrary.DataSource.Interfaces;
using BukasBa.CoreLibrary.Models.DTO;
using BukasBa.CoreLibrary.Models.UI;
using GalaSoft.MvvmLight.Command;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BukasBa.CoreLibrary.ViewModels.Store
{
    public class ViewModel_StoreOwnerRegistration : VMBase
    {
        #region events

        #endregion

        #region vars

        #endregion

        #region properties
        private Model_AuthDetails _AuthDetails = new Model_AuthDetails();
        public Model_AuthDetails AuthDetails
        {
            get { return _AuthDetails; }
            set { Set(nameof(AuthDetails), ref _AuthDetails, value); }
        }
        #endregion

        #region commands
        public ICommand Command_Register { get; set; }
        #endregion

        #region ctors
        public ViewModel_StoreOwnerRegistration(IDataLocator dataLocator)
        {
            InitCommands();
            this._data = dataLocator;
        }
        #endregion

        #region command methods
        async void Command_Register_Click()
        {
            var resp = await _data.AuthService.RegisterStoreOwner(new DTO_AuthDetails()
            {
                Username = this.AuthDetails.Username,
                Password = this.AuthDetails.Password
            });

            if (resp.IsOk)
            {
                _data.Token = (string)resp.Response;
                _data.UserId = resp.Attributes["localid"];
            }
            else
            {
                var response = (string)resp.Response;
                switch(response)
                {
                    case "INVALID_EMAIL":
                        await this.Dialog.ShowMessage("Invalid Email", "Invalid", "ok", null);
                        break;
                    case "EMAIL_EXISTS":
                        await this.Dialog.ShowMessage("Email Exists", "Invalid", "ok", null);
                        break;
                }
            }
        }
        #endregion

        #region methods
        public override void InitCommands()
        {
            base.InitCommands();

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