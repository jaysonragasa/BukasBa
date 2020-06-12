using BukasBa.CoreLibrary.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BukasBa.CoreLibrary.DataSource.Interfaces
{
    public interface IStoreService
    {
        Task<string> UploadFileAsync(string localimagepath, string token);
        Task<List<IModelStoreDetails>> GetAllAsync();
        Task<List<IModelStoreDetails>> GetAllByAccountAsync(string id);
        Task<IBaseResponse> CreateNewAsync(IModelStoreDetails store);
        Task<IBaseResponse> UpdateStoreAsync(IModelStoreDetails store);
        Task<List<IModelStoreDetails>> GetAllAsync(string storename = "");
        Task<IBaseResponse> CheckIfTheseStoresAreOpenAsync(List<IModelStoreDetails> favstores);
        Task<IBaseResponse> DeleteStoreAsync(IModelStoreDetails store);
    }
}