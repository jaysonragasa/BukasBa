#define DEMO

using BukasBa.CoreLibrary.DataSource.Demo;
using BukasBa.CoreLibrary.DataSource.Interfaces;
using BukasBa.CoreLibrary.ViewModels.Customer;
using BukasBa.CoreLibrary.ViewModels.Store;

using GalaSoft.MvvmLight.Ioc;

namespace BukasBa.CoreLibrary.ViewModels
{
    public class ViewModelLocator
    {
        IDataLocator _dataLocator;

        #region store
        public ViewModel_StoreRegistration StoreRegistration => SimpleIoc.Default.GetInstance<ViewModel_StoreRegistration>();
        public ViewModel_StoreDashboard StoreDashboard => SimpleIoc.Default.GetInstance<ViewModel_StoreDashboard>();
        #endregion

        #region customer
        public ViewModel_Favorites Favorites => SimpleIoc.Default.GetInstance<ViewModel_Favorites>();
        public ViewModel_StoreListing StoreLists => SimpleIoc.Default.GetInstance<ViewModel_StoreListing>();
        #endregion

        public ViewModelLocator()
        {
#if DEMO
            _dataLocator = new DemoDataLocator();
#else
#endif

            // store VMs
            SimpleIoc.Default.Register<ViewModel_StoreRegistration>();
            SimpleIoc.Default.Register<ViewModel_StoreDashboard>();

            // customer VMs
            SimpleIoc.Default.Register<ViewModel_Favorites>();
            SimpleIoc.Default.Register(() => new ViewModel_StoreListing(this._dataLocator));
        }
    }
}