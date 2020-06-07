using BukasBa.CoreLibrary.Models.Interfaces;
using System.Threading.Tasks;

namespace BukasBa.CoreLibrary.DataSource.Interfaces
{
    public interface IAuthService
    {
        Task<IBaseResponse> LoginAsync(IModelAuthDetails auth);
        Task<IBaseResponse> RegisterStoreOwner(IModelAuthDetails auth);
    }
}