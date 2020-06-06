using BukasBa.CoreLibrary.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BukasBa.CoreLibrary.DataSource.Interfaces
{
    public interface IStoresService
    {
        Task<List<IModelStoreDetails>> GetAllAsync();
    }
}