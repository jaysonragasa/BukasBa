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

        private bool _ShowFilterBox = false;
        public bool ShowFilterBox
        {
            get { return _ShowFilterBox; }
            set { Set(nameof(ShowFilterBox), ref _ShowFilterBox, value); }
        }

        private string _FilterStoreName = string.Empty;
        public string FilterStoreName
        {
            get { return _FilterStoreName; }
            set { Set(nameof(FilterStoreName), ref _FilterStoreName, value); }
        }
        #endregion

        #region commands
        public ICommand Command_ShowDetails { get; set; }
        public ICommand Command_AddToFavorites { get; set; }
        public ICommand Command_CloseStoreDetails { get; set; }
        public ICommand Command_ShowAddressOnMap { get; set; }
        public ICommand Command_OpenFilterBox { get; set; }
        public ICommand Command_ApplyFilter { get; set; }
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

        async void Command_AddToFavorites_Click(Model_StoreDetails store)
        {
            var ret = await _data.CustomerService.SaveToFavorites(store);

            if(ret)
            {
                await this.Dialog.ShowMessage("Saved to your favorites", "Saved", "ok", null);
            }

            this.SelectedStore = store;
        }

        void Command_CloseStoreDetails_Click()
        {
            this.ShowStoreDetails = false;
        }

        void Command_ShowAddressOnMap_Click()
        {

        }

        void Command_OpenFilterBox_Click()
        {
            this.ShowFilterBox = true;
        }

        async void Command_ApplyFilter_Click()
        {
            await RefreshData(this.FilterStoreName);
            this.ShowFilterBox = false;
        }

        void Command_TapBackdropToClose_Click()
        {
            this.ShowFilterBox = false;
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
            if (Command_OpenFilterBox == null) Command_OpenFilterBox = new RelayCommand(Command_OpenFilterBox_Click);
            if (Command_ApplyFilter == null) Command_ApplyFilter = new RelayCommand(Command_ApplyFilter_Click);
            if (Command_TapBackdropToClose == null) Command_TapBackdropToClose = new RelayCommand(Command_TapBackdropToClose_Click);
        }

        void DesignData()
        {

        }

        void RuntimeData()
        {

        }

        public async Task RefreshData(string storename = "")
        {
            this.ShowDialog("Loading stores", "please wait ...");

            var stores = await this._data.StoresService.GetAllAsync(storename);

            this.StoreCollection.Clear();
            for (int i = 0; i < stores.Count; i++)
            {
                this.StoreCollection.Add(Mappy.I.Map<Model_StoreDetails>(stores[i]));
            }

            this.HideDialog();
        }
        #endregion
    }
}