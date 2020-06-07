using BukasBa.CoreLibrary.DataSource.Interfaces;

namespace BukasBa.CoreLibrary.DataSource.Demo
{
    public class DemoDataLocator : IDataLocator
    {
        public IStoreService StoresService { get; set; }
        public ICustomerService CustomerService { get; set; }
        public IAuthService AuthService { get; set; }

        public DemoDataLocator()
        {
            this.StoresService = new DemoStoresService();
            this.CustomerService = new DemoCustomerService();
            this.AuthService = new DemoAuthService();
        }
    }
}