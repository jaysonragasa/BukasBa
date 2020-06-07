using BukasBa.CoreLibrary.DataSource.Interfaces;
using BukasBa.CoreLibrary.DataSource.Models;
using BukasBa.CoreLibrary.Models.Interfaces;
using BukasBa.DataSource.Models;

using Firebase.Auth;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace BukasBa.CoreLibrary.DataSource.Firebase
{
    public class AuthService : IAuthService
    {
        string AuthKey { get; set; } = "";

        public async Task<IBaseResponse> LoginAsync(IModelAuthDetails auth)
        {
            BaseResponse response = new BaseResponse();

            var a = new FirebaseAuthProvider(new FirebaseConfig(AuthKey));

            try
            {
                var authLink = await a.SignInWithEmailAndPasswordAsync(auth.Username, auth.Password);

                response.IsOk = true;
                response.Message = "CreateStoreAccount";
                response.Response = authLink.FirebaseToken;
                response.Attributes.Add("token", authLink.FirebaseToken);
                response.Attributes.Add("localid", authLink.User.LocalId);
            }
            catch (FirebaseAuthException ex)
            {
                string json = ex.ResponseData;
                var fbr = (FirebaseResponse)JsonConvert.DeserializeObject<FirebaseResponse>(json);
                response.IsOk = false;
                response.Response = fbr.Message;
            }

            return response;
        }

        public async Task<IBaseResponse> RegisterStoreOwner(IModelAuthDetails auth)
        {
            BaseResponse response = new BaseResponse();

            var a = new FirebaseAuthProvider(new FirebaseConfig(AuthKey));

            try
            {
                var authLink = await a.CreateUserWithEmailAndPasswordAsync(auth.Username, auth.Password, auth.Username, false);

                response.IsOk = true;
                response.Message = "RegisterStoreOwner";
                response.Response = authLink.FirebaseToken;
                response.Attributes.Add("token", authLink.FirebaseToken);
                response.Attributes.Add("localid", authLink.User.LocalId);
            }
            catch(FirebaseAuthException ex)
            {
                string json = ex.ResponseData;
                var fbr = (FirebaseResponse)JsonConvert.DeserializeObject<FirebaseResponse>(json);
                response.IsOk = false;
                response.Response = fbr.error.message;
            }

            return response;
        }
    }
}