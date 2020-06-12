using BukasBa.CoreLibrary.DataSource.Interfaces;
using BukasBa.CoreLibrary.Helpers;
using BukasBa.CoreLibrary.Models;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BukasBa.CoreLibrary.ViewModels.Store
{
    public class ViewModel_StoreDashboard : VMBase
    {
        #region events

        #endregion

        #region vars

        #endregion

        #region properties
        public ObservableCollection<Model_StoreDetails> StoreCollections { get; set; } = new ObservableCollection<Model_StoreDetails>();
        #endregion

        #region commands
        public ICommand Command_CloseStore { get; set; }
        public ICommand Command_OpenStore { get; set; }
        public ICommand Command_ShowDetails { get; set; }
        public ICommand Command_CreateStore { get; set; }
        #endregion

        #region ctors
        public ViewModel_StoreDashboard(IDataLocator dataLocator)
        {
            InitCommands();

            this._data = dataLocator;
        }
        #endregion

        #region command methods
        void Command_CloseStore_Click(Model_StoreDetails store)
        {
            store.IsOpen = false;
            this._data.StoresService.UpdateStoreAsync(store);
        }

        void Command_OpenStore_Click(Model_StoreDetails store)
        {
            store.IsOpen = true;
            this._data.StoresService.UpdateStoreAsync(store);
        }

        void Command_ShowDetails_Click(Model_StoreDetails store)
        {
            var vm = SimpleIoc.Default.GetInstance<ViewModel_StoreRegistration>();
            vm.StoreDetails = store;
            vm.SelectedImagePath = store.ImagePath;
            vm.IsUpdate = true;

            this.Nav.NavigateTo(Enums.Enum_Pages.STOREOWNER_STOREREGISTRATION);
        }

        void Command_CreateStore_Click()
        {
            this.Nav.NavigateTo(Enums.Enum_Pages.STOREOWNER_STOREREGISTRATION);
        }
        #endregion

        #region methods
        public override void InitCommands()
        {
            base.InitCommands();

            if (Command_CloseStore == null) Command_CloseStore = new RelayCommand<Model_StoreDetails>(Command_CloseStore_Click);
            if (Command_OpenStore == null) Command_OpenStore = new RelayCommand<Model_StoreDetails>(Command_OpenStore_Click);
            if (Command_ShowDetails == null) Command_ShowDetails = new RelayCommand<Model_StoreDetails>(Command_ShowDetails_Click);
            if (Command_CreateStore == null) Command_CreateStore = new RelayCommand(Command_CreateStore_Click);
        }

        void DesignData()
        {

        }

        void RuntimeData()
        {

        }

        public async Task RefreshData()
        {
            this.ShowDialog("Loading your stores", "please wait ...");

            var stores = await this._data.StoresService.GetAllByAccountAsync(this._data.UserId);

            if (stores.Any())
            {
                this.StoreCollections.Clear();
                for (int i = 0; i < stores.Count; i++)
                {
                    if (stores[i].IsOperational)
                    {
                        this.StoreCollections.Add(Mappy.I.Map<Model_StoreDetails>(stores[i]));
                    }
                }
            }

            this.HideDialog();
        }
        #endregion
    }
}