using BukasBa.CoreLibrary.ViewModels.Customer;
using BukasBa.CoreLibrary.ViewModels.Store;

using GalaSoft.MvvmLight.Ioc;

namespace BukasBa.CoreLibrary.ViewModels
{
    public class ViewModelLocator
    {
        #region store
        public ViewModel_StoreRegistration StoreRegistration => SimpleIoc.Default.GetInstance<ViewModel_StoreRegistration>();
        public ViewModel_StoreDashboard StoreDashboard => SimpleIoc.Default.GetInstance<ViewModel_StoreDashboard>();
        #endregion

        #region customer
        public ViewModel_Favorites Favorites => SimpleIoc.Default.GetInstance<ViewModel_Favorites>();
        public ViewModel_StoreListing StoreListing => SimpleIoc.Default.GetInstance<ViewModel_StoreListing>();
        #endregion

        public ViewModelLocator()
        {
            // store VMs
            SimpleIoc.Default.Register<ViewModel_StoreRegistration>();
            SimpleIoc.Default.Register<ViewModel_StoreDashboard>();

            // customer VMs
            SimpleIoc.Default.Register<ViewModel_Favorites>();
            SimpleIoc.Default.Register<ViewModel_StoreListing>();
        }
    }
}