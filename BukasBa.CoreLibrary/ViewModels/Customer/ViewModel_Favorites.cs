using BukasBa.CoreLibrary.DataSource.Interfaces;
using BukasBa.CoreLibrary.Helpers;
using BukasBa.CoreLibrary.Models;
using BukasBa.CoreLibrary.Models.Interfaces;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ICommand Command_Remove { get; set; }
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

        async void Command_Remove_Click(Model_StoreDetails store)
        {
            var res = await this._data.CustomerService.RemoveToFavorites(store);
            if(res)
            {
                this.StoreCollections.Remove(store);
            }
            else
            {
                await this.Dialog.ShowMessage("Unable to remove the current item", "Removing item", "ok", null);
            }
        }
        #endregion

        #region methods
        public override void InitCommands()
        {
            base.InitCommands();

            if (Command_ShowDetails == null) Command_ShowDetails = new RelayCommand<Model_StoreDetails>(Command_ViewStoreDetails_Click);
            if (Command_CloseStoreDetails == null) Command_CloseStoreDetails = new RelayCommand(Command_CloseStoreDetails_Click);
            if (Command_Remove == null) Command_Remove = new RelayCommand<Model_StoreDetails>(Command_Remove_Click);
        }

        void DesignData()
        {

        }

        void RuntimeData()
        {

        }

        public async Task RefreshData()
        {
            this.ShowDialog("Loading stores", "please wait ...");

            this.StoreCollections.Clear();

            var favstores = await this._data.CustomerService.GetAllFavoritesAsync();

            // check if they are open or not
            var store = await this._data.StoresService.CheckIfTheseStoresAreOpenAsync(favstores);

            if (store.IsOk)
            {
                var storelist = ((List<IModelStoreDetails>)store.Response);
                for (int i = 0; i < storelist.Count; i++)
                {
                    this.StoreCollections.Add(Mappy.I.Map<Model_StoreDetails>(storelist[i]));
                }
            }
            else
            {
                for (int i = 0; i < favstores.Count; i++)
                {
                    this.StoreCollections.Add(Mappy.I.Map<Model_StoreDetails>(favstores[i]));
                }
            }

            this.HideDialog();
        }
        #endregion
    }
}