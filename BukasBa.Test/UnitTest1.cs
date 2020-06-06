using System;
using System.Threading.Tasks;
using BukasBa.CoreLibrary.DataSource.Demo;
using BukasBa.CoreLibrary.DataSource.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BukasBa.Test
{
    [TestClass]
    public class UnitTest1
    {
        IDataLocator _data = new DemoDataLocator();

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
    }
}
