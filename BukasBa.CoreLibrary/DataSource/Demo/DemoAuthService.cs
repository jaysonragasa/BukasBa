using BukasBa.CoreLibrary.DataSource.Interfaces;
using BukasBa.CoreLibrary.Models.Interfaces;
using BukasBa.DataSource.Models;
using System.Threading.Tasks;

namespace BukasBa.CoreLibrary.DataSource.Demo
{
    public class DemoAuthService : IAuthService
    {
        public async Task<IBaseResponse> LoginAsync(IModelAuthDetails auth)
        {
            return new BaseResponse()
            {
                IsOk = true
            };
        }

        public Task<IBaseResponse> RegisterStoreOwner(IModelAuthDetails auth)
        {
            throw new System.NotImplementedException();
        }
    }
}