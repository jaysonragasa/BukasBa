using BukasBa.CoreLibrary.DataSource.Interfaces;
using BukasBa.CoreLibrary.Helpers;
using BukasBa.CoreLibrary.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BukasBa.CoreLibrary.ViewModels.Customer
{
    public class ViewModel_Favorites : VMBase
    {
        #region events

        #endregion

        #region vars

        #endregion

        #region properties
        public ObservableCollection<Model_StoreDetails> StoreCollections { get; set; } = new ObservableCollection<Model_StoreDetails>();

        private Model_StoreDetails _storeDetails = new Model_StoreDetails();
        public Model_StoreDetails SelectedStore
        {
            get { return _storeDetails; }
            set { Set(nameof(SelectedStore), ref _storeDetails, value); }
        }

        private bool _ShowStoreDetails = false;
        public bool ShowStoreDetails
        {
            get { return _ShowStoreDetails; }
            set { Set(nameof(ShowStoreDetails), ref _ShowStoreDetails, value); }
        }
        #endregion

        #region commands
        public ICommand Command_ShowDetails { get; set; }
        public ICommand Command_CloseStoreDetails { get; set; }
        #endregion

        #region ctors
        public ViewModel_Favorites(IDataLocator dataLocator)
        {
            InitCommands();

            this._data = dataLocator;
        }
        #endregion

        #region command methods
        void Command_ViewStoreDetails_Click(Model_StoreDetails store)
        {
            this.SelectedStore = store;
            this.ShowStoreDetails = true;
        }

        void Command_CloseStoreDetails_Click()
        {
            this.ShowStoreDetails = false;
        }
        #endregion

        #region methods
        public override void InitCommands()
        {
            base.InitCommands();

            if (Command_ShowDetails == null) Command_ShowDetails = new RelayCommand<Model_StoreDetails>(Command_ViewStoreDetails_Click);
            if (Command_CloseStoreDetails == null) Command_CloseStoreDetails = new RelayCommand(Command_CloseStoreDetails_Click);
        }

        void DesignData()
        {

        }

        void RuntimeData()
        {

        }

        public async Task RefreshData()
        {
            var stores = await this._data.CustomerService.GetAllFavoritesAsync();

            this.StoreCollections.Clear();
            for(int i = 0; i < stores.Count; i++)
            {
                this.StoreCollections.Add(Mappy.I.Map<Model_StoreDetails>(stores[i]));
            }
        }
        #endregion
    }
}