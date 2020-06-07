using BukasBa.CoreLibrary.DataSource.Interfaces;
using BukasBa.CoreLibrary.Models.DTO;
using BukasBa.CoreLibrary.Models.Interfaces;
using BukasBa.DataSource.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BukasBa.CoreLibrary.DataSource.Firebase
{
    public class StoreService : FirebaseBase, IStoreService
    {
        public async Task<string> UploadFile(string localimagepath, string token)
        {
            string result = string.Empty;

            try
            {
                result = await this.FileUploader.UploadFileAsync(localimagepath, token);
            }
            catch(Exception ex)
            {
                result = null;
            }

            return result;
        }

        public async Task<IBaseResponse> CreateNewAsync(IModelStoreDetails store)
        {
            BaseResponse response = new BaseResponse();

            var result = await this.CRUD.AddAsync("STORES", store.Id, store, true);

            response.IsOk = result;

            return response;
        }

        public async Task<List<IModelStoreDetails>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<IModelStoreDetails>> GetAllByAccount(string id)
        {
            List<DTO_StoreDetails> list = new List<DTO_StoreDetails>();
            List<IModelStoreDetails> ilist = new List<IModelStoreDetails>();

            var result = await this.CRUD.GetAllAsync<DTO_StoreDetails>("STORES");

            if (result.Any())
            {
                var ownerstores = result.Where(x => x.OwnerId == id);

                //list = ownerstores.Any() ? ownerstores.ToList() : null;
                if(ownerstores.Any())
                {
                    for(int i = 0; i < ownerstores.Count(); i++)
                    {
                        ilist.Add(ownerstores.ElementAt(i));
                    }
                }
            }

            return ilist;
        }
    }
}