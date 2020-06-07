using BukasBa.CoreLibrary.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BukasBa.CoreLibrary.DataSource.Interfaces
{
    public interface IStoreService
    {
        Task<List<IModelStoreDetails>> GetAllAsync();
        Task<IModelStoreDetails> CreateNewAsync(IModelStoreDetails store);
    }
}