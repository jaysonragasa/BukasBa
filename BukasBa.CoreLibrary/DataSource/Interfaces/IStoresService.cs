using BukasBa.CoreLibrary.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BukasBa.CoreLibrary.DataSource.Interfaces
{
    public interface IStoreService
    {
        Task<string> UploadFile(string localimagepath, string token);
        Task<List<IModelStoreDetails>> GetAllAsync();
        Task<List<IModelStoreDetails>> GetAllByAccount(string id);
        Task<IBaseResponse> CreateNewAsync(IModelStoreDetails store);
        Task<IBaseResponse> UpdateStore(IModelStoreDetails store);
    }
}