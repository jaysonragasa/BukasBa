#undef DEMO

using BukasBa.CoreLibrary.DataSource.Demo;
using BukasBa.CoreLibrary.DataSource.Firebase;
using BukasBa.CoreLibrary.DataSource.Interfaces;
using BukasBa.CoreLibrary.Models.DTO;
using BukasBa.CoreLibrary.ViewModels.Customer;
using BukasBa.CoreLibrary.ViewModels.Store;

using GalaSoft.MvvmLight.Ioc;
using System.Threading.Tasks;

namespace BukasBa.CoreLibrary.ViewModels
{
    public class ViewModelLocator
    {
        IDataLocator _dataLocator;

        public ViewModel_Login Login => SimpleIoc.Default.GetInstance<ViewModel_Login>();

        #region store
        public ViewModel_StoreRegistration StoreRegistration => SimpleIoc.Default.GetInstance<ViewModel_StoreRegistration>();
        public ViewModel_StoreDashboard StoreDashboard => SimpleIoc.Default.GetInstance<ViewModel_StoreDashboard>();
        public ViewModel_StoreOwnerRegistration StoreOwnerReg => SimpleIoc.Default.GetInstance<ViewModel_StoreOwnerRegistration>();
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
            _dataLocator = new DataLocator();
#endif

            SimpleIoc.Default.Register(() => new ViewModel_Login(this._dataLocator));

            // store VMs
            SimpleIoc.Default.Register(() => new ViewModel_StoreRegistration(this._dataLocator));
            SimpleIoc.Default.Register(() => new ViewModel_StoreDashboard(this._dataLocator));

            // customer VMs
            SimpleIoc.Default.Register(() => new ViewModel_Favorites(this._dataLocator));
            SimpleIoc.Default.Register(() => new ViewModel_StoreListing(this._dataLocator));
            SimpleIoc.Default.Register(() => new ViewModel_StoreOwnerRegistration(this._dataLocator));

            // temp login
            var t = Task.Run(async () =>
            {
                var resp = await _dataLocator.AuthService.LoginAsync(new DTO_AuthDetails()
                {
                    Username = "jayson@gmail.com",
                    Password = "zeroslot"
                });

                if(resp.IsOk)
                {
                    _dataLocator.Token = resp.Attributes["token"];
                    _dataLocator.UserId = resp.Attributes["localid"];
                }
            });
            t.Wait();
        }
    }
}