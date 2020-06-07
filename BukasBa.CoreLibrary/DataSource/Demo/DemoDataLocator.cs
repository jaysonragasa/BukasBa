using BukasBa.CoreLibrary.DataSource.Interfaces;

namespace BukasBa.CoreLibrary.DataSource.Demo
{
    public class DemoDataLocator : IDataLocator
    {
        public IStoresService StoresService { get; set; }
        public ICustomerService CustomerService { get; set; }

        public DemoDataLocator()
        {
            this.StoresService = new DemoStoresService();
            this.CustomerService = new DemoCustomerService();
        }
    }
}