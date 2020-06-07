using BukasBa.CoreLibrary.DataSource.Interfaces;
using System;

namespace BukasBa.CoreLibrary.DataSource.Firebase
{
    public class DataLocator : IDataLocator
    {
        public IStoreService StoresService { get; set; }
        public ICustomerService CustomerService { get; set; }
        public IAuthService AuthService { get; set; }

        public DataLocator()
        {

        }
    }
}