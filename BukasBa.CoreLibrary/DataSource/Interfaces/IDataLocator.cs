namespace BukasBa.CoreLibrary.DataSource.Interfaces
{
    public interface IDataLocator
    {
        IStoresService StoresService { get; set; }
    }
}