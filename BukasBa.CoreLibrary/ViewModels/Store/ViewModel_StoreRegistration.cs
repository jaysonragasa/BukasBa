using BukasBa.CoreLibrary.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BukasBa.CoreLibrary.ViewModels.Store
{
    public class ViewModel_StoreRegistration : VMBase
    {
        #region events
        public EventHandler OnCameraTapped;
        #endregion

        #region vars

        #endregion

        #region properties
        private Model_StoreDetails _storeDetails = new Model_StoreDetails();
        public Model_StoreDetails StoreDetails
        {
            get { return _storeDetails; }
            set { Set(nameof(StoreDetails), ref _storeDetails, value); }
        }
        #endregion

        #region commands
        public ICommand Command_OpenCamera { get; set; }
        public ICommand Command_Register { get; set; }
        public ICommand Command_OpenMap { get; set; }
        #endregion

        #region ctors
        public ViewModel_StoreRegistration()
        {
            InitCommands();
        }
        #endregion

        #region command methods
        void Command_Register_Click()
        {

        }

        void Command_OpenMap_Click()
        {

        }

        void Command_OpenCamera_Click()
        {
            this.OnCameraTapped?.Invoke(this, null);
        }
        #endregion

        #region methods
        public override void InitCommands()
        {
            base.InitCommands();

            if (Command_Register == null) Command_Register = new RelayCommand(Command_Register_Click);
            if (Command_OpenMap == null) Command_OpenMap = new RelayCommand(Command_OpenMap_Click);
            if (Command_OpenCamera == null) Command_OpenCamera = new RelayCommand(Command_OpenCamera_Click);
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