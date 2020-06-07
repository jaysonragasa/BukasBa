namespace BukasBa.CoreLibrary.DataSource.Interfaces
{
    public interface IDataLocator
    {
        IStoreService StoresService { get; set; }
        ICustomerService CustomerService { get; set; }
        IAuthService AuthService { get; set; }
    }
}