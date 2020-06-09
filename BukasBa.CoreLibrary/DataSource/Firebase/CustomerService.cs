using BukasBa.CoreLibrary.DataSource.Interfaces;
using BukasBa.CoreLibrary.Models.Interfaces;

using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BukasBa.CoreLibrary.DataSource.Firebase
{
    public class CustomerService : ICustomerService
    {
        // https://doumer.me/litedb-on-xamarin-forms-alternative-to-sqlite/
        //var d = Path.Combine(ApplicationData.Current.LocalFolder.Path, Constants.OFFLINE_DATABASE_NAME);

        public async Task<List<IModelStoreDetails>> GetAllFavoritesAsync()
        {
            List<IModelStoreDetails> ret = new List<IModelStoreDetails>();

            string localappdata = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string dbfile = Path.Combine(localappdata, "localdb.db");

            using (var ldb = new LiteDatabase(dbfile))
            {
                var stores = ldb.GetCollection<IModelStoreDetails>("stores");
                var all = stores.FindAll();

                for (int i = 0; i < all.Count(); i++)
                {
                    ret.Add(all.ElementAt(i));
                }
            }

            return ret;
        }

        public async Task<bool> SaveToFavorites(IModelStoreDetails store)
        {
            bool ret = false;
            
            string localappdata = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string dbfile = Path.Combine(localappdata, "localdb.db");

            using (var ldb = new LiteDatabase(dbfile))
            {
                var stores = ldb.GetCollection<IModelStoreDetails>("stores");
                stores.EnsureIndex(x => x.Id, true);

                try
                {
                    store.IsOpen = false;

                    stores.Insert(store);

                    ret = true;
                }
                catch(Exception ex)
                {
                    ret = false;
                }
            }

            return ret;
        }

        public async Task<bool> RemoveToFavorites(IModelStoreDetails store)
        {
            bool ret = false;

            string localappdata = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string dbfile = Path.Combine(localappdata, "localdb.db");

            using (var ldb = new LiteDatabase(dbfile))
            {
                var stores = ldb.GetCollection<IModelStoreDetails>("stores");

                try
                {
                    stores.Delete(store.Id);
                    ret = true;
                }
                catch (Exception ex)
                {
                    ret = false;
                }
            }

            return ret;
        }
    }
}