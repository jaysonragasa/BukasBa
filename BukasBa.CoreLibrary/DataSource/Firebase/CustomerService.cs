using BukasBa.CoreLibrary.DataSource.Interfaces;
using BukasBa.CoreLibrary.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BukasBa.CoreLibrary.DataSource.Firebase
{
    public class CustomerService : ICustomerService
    {
        public Task<IModelStoreDetails> CreateNewAsync(IModelStoreDetails store)
        {
            throw new NotImplementedException();
        }

        public Task<List<IModelStoreDetails>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<IModelStoreDetails>> GetAllFavoritesAsync()
        {
            throw new NotImplementedException();
        }
    }
}