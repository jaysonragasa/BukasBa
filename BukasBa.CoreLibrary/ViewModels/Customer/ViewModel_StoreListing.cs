using BukasBa.CoreLibrary.DataSource.Interfaces;
using BukasBa.CoreLibrary.Helpers;
using BukasBa.CoreLibrary.Models;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BukasBa.CoreLibrary.ViewModels.Customer
{
    public class ViewModel_StoreListing : VMBase
    {
        #region events

        #endregion

        #region vars

        #endregion

        #region properties
        public ObservableCollection<Model_StoreDetails> StoreCollection { get; set; } = new ObservableCollection<Model_StoreDetails>();

        private Model_StoreDetails _SelectedStore = new Model_StoreDetails();
        public Model_StoreDetails SelectedStore
        {
            get { return _SelectedStore; }
            set { Set(nameof(SelectedStore), ref _SelectedStore, value); }
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
        public ICommand Command_AddToFavorites { get; set; }
        public ICommand Command_CloseStoreDetails { get; set; }
        public ICommand Command_ShowAddressOnMap { get; set; }
        #endregion

        #region ctors
        public ViewModel_StoreListing(IDataLocator dataLocator)
        {
            this._data = dataLocator;

            InitCommands();
        }
        #endregion

        #region command methods
        void Command_ShowDetails_Click(Model_StoreDetails store)
        {
            this.SelectedStore = store;

            this.ShowStoreDetails = true;
        }

        void Command_AddToFavorites_Click(Model_StoreDetails store)
        {
            this.SelectedStore = store;
        }

        void Command_CloseStoreDetails_Click()
        {
            this.ShowStoreDetails = false;
        }

        void Command_ShowAddressOnMap_Click()
        {

        }
        #endregion

        #region methods
        public override void InitCommands()
        {
            base.InitCommands();

            if (Command_ShowDetails == null) Command_ShowDetails = new RelayCommand<Model_StoreDetails>(Command_ShowDetails_Click);
            if (Command_AddToFavorites == null) Command_AddToFavorites = new RelayCommand<Model_StoreDetails>(Command_AddToFavorites_Click);
            if (Command_CloseStoreDetails == null) Command_CloseStoreDetails = new RelayCommand(Command_CloseStoreDetails_Click);
            if (Command_ShowAddressOnMap == null) Command_ShowAddressOnMap = new RelayCommand(Command_ShowAddressOnMap_Click);

        }

        void DesignData()
        {

        }

        void RuntimeData()
        {

        }

        public async Task RefreshData()
        {
            var stores = await this._data.StoresService.GetAllAsync();

            this.StoreCollection.Clear();
            for (int i = 0; i < stores.Count; i++)
            {
                this.StoreCollection.Add(Mappy.I.Map<Model_StoreDetails>(stores[i]));
            }
        }
        #endregion
    }
}