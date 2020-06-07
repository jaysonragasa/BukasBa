namespace BukasBa.CoreLibrary.DataSource.Interfaces
{
    public interface IDataLocator
    {
        string Token { get; set; }
        string UserId { get; set; }

        IStoreService StoresService { get; set; }
        ICustomerService CustomerService { get; set; }
        IAuthService AuthService { get; set; }
    }
}