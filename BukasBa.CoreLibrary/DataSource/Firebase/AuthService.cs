using BukasBa.CoreLibrary.DataSource.Interfaces;
using BukasBa.CoreLibrary.Models.Interfaces;
using System;
using System.Threading.Tasks;

namespace BukasBa.CoreLibrary.DataSource.Firebase
{
    public class AuthService : IAuthService
    {
        public Task<IBaseResponse> LoginAsync(IModelAuthDetails auth)
        {
            throw new NotImplementedException();
        }
    }
}