using BukasBa.CoreLibrary.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BukasBa.CoreLibrary.DataSource.Interfaces
{
    public interface ICustomerService
    {
        Task<List<IModelStoreDetails>> GetAllFavoritesAsync();
        Task<bool> SaveToFavorites(IModelStoreDetails store);
        Task<bool> RemoveToFavorites(IModelStoreDetails store);
    }
}