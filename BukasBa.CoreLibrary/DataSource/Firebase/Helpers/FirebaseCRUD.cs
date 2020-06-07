using Firebase.Database;
using Firebase.Database.Query;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BukasBa.CoreLibrary.DataSource.Firebase.Helpers
{
    public class FirebaseCRUD
    {
        public static FirebaseCRUD Instance => new Lazy<FirebaseCRUD>().Value;

        public FirebaseClient FireClient { get; set; }

        public async Task<bool> AddAsync<T>(string document, string id, T item, bool autoKey = false, Expression<Func<object, bool>> WhereEx = null, string messageIfExists = null) where T : class
        {
            bool result = false;

            if (this.FireClient == null) return false;

            try
            {
                //var response = await this.FireClient.Child(document).Child(id).PostAsync<T>(item); // we don't want any random key being generated randomly by Post so we'll use PutAsync

                await this.FireClient.Child(document).Child(id).PutAsync<T>(item);

                result = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                result = false;
            }

            return result;
        }

        public async Task<T> GetItemAsync<T>(string document, string id) where T : class
        {
            T result;

            if (this.FireClient == null) return null;

            try
            {
                result = await this.FireClient.Child(document).Child(id).OnceSingleAsync<T>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                result = null;
            }

            return result;
        }

        public async Task<List<T>> GetAllAsync<T>(string document) where T : class
        {
            List<T> result;

            if (this.FireClient == null) return null;

            try
            {
                var response = await this.FireClient.Child(document).OnceAsync<T>();
                var objects = response.Select(x => x.Object);

                result = objects.ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                result = null;
            }

            return result;
        }

        public async Task<bool> UpdateAsync<T>(string document, string id, T item) where T : class
        {
            bool result = false;

            var add_result = await AddAsync(document, id, item);

            if (add_result)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
    }
}