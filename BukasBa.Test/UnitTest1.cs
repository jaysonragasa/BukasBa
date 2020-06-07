using System;
using System.Threading.Tasks;

using BukasBa.CoreLibrary.DataSource.Demo;
using BukasBa.CoreLibrary.DataSource.Firebase;
using BukasBa.CoreLibrary.DataSource.Interfaces;
using BukasBa.CoreLibrary.Models.DTO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BukasBa.Test
{
    [TestClass]
    public class UnitTest1
    {
        IDataLocator _data = new DataLocator();

        [TestMethod]
        public async Task TestMethod1()
        {
            //var stores = await _data.StoresService.GetAllAsync();

            //Assert.IsTrue(stores.Count > 0);

            var ts = new TimeSpan(17, 0, 0);
            var ds = new DateTime(ts.Ticks);

            string format = ds.ToString("h:mm");

            Assert.IsTrue(true);
        }

        [TestMethod]
        public async Task CreateStoreOwner()
        {
            var store = await _data.AuthService.RegisterStoreOwner(new DTO_AuthDetails()
            {
                Username = "jayson.d.ragasa@gmail.com",
                Password = "Xamarin++",
                IsStore = true
            });

            Assert.IsTrue(store.IsOk);
        }

        [TestMethod]
        public async Task LoginStoreOwner()
        {
            var store = await _data.AuthService.LoginAsync(new DTO_AuthDetails()
            {
                Username = "jayson.d.ragasa@gmail.com",
                Password = "Xamarin++",
                IsStore = true
            });

            Assert.IsTrue(store.IsOk);
        }

        [TestMethod]
        public async Task CreateStore()
        {
            var result = await _data.StoresService.CreateNewAsync(new DTO_StoreDetails()
            {
                Id = Guid.NewGuid().ToString(),
                StoreName = "Hello"
            });

            Assert.IsTrue(true);
        }
    }
}
