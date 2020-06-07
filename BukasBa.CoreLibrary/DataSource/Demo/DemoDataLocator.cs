using BukasBa.CoreLibrary.DataSource.Interfaces;

namespace BukasBa.CoreLibrary.DataSource.Demo
{
    public class DemoDataLocator : IDataLocator
    {
        public string Token { get; set; }
        public string UserId { get; set; } = null;

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