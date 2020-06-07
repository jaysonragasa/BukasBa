using BukasBa.CoreLibrary.DataSource.Interfaces;

namespace BukasBa.CoreLibrary.DataSource.Firebase
{
    public class DataLocator : IDataLocator
    {
        public string Token { get; set; } = null;
        public string UserId { get; set; } = null;

        public IStoreService StoresService { get; set; }
        public ICustomerService CustomerService { get; set; }
        public IAuthService AuthService { get; set; }

        public DataLocator()
        {
            StoresService = new StoreService();
            CustomerService = new CustomerService();
            AuthService = new AuthService();
        }
    }
}