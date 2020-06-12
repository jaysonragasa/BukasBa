using BukasBa.CoreLibrary.Models.Interfaces;
using GalaSoft.MvvmLight;
using System;

namespace BukasBa.CoreLibrary.Models
{
    public class Model_StoreDetails : ViewModelBase, IModelStoreDetails
    {
        public string Id { get; set; }

        public string ImagePath { get; set; } = string.Empty;

        private string _storeName = string.Empty;
        public string StoreName
        {
            get { return _storeName; }
            set { Set(nameof(StoreName), ref _storeName, value); }
        }

        private string _address = string.Empty;
        public string Address
        {
            get { return _address; }
            set { Set(nameof(Address), ref _address, value); }
        }

        private string _contactNumber = string.Empty;
        public string ContactNumber
        {
            get { return _contactNumber; }
            set { Set(nameof(ContactNumber), ref _contactNumber, value); }
        }

        public double Geo_Longitude { get; set; } = 0.0d;

        public double Geo_Latitude { get; set; } = 0.0d;

        private TimeSpan _storeOpen = new TimeSpan();
        public TimeSpan StoreOpen
        {
            get { return _storeOpen; }
            set { Set(nameof(StoreOpen), ref _storeOpen, value); }
        }

        private TimeSpan _storeClosed = new TimeSpan();
        public TimeSpan StoreClosed
        {
            get { return _storeClosed; }
            set { Set(nameof(StoreClosed), ref _storeClosed, value); }
        }

        private bool _isOpen = false;
        public bool IsOpen
        {
            get { return _isOpen; }
            set { Set(nameof(IsOpen), ref _isOpen, value); }
        }

        public string OwnerId { get; set; } = null;

        private bool _IsOperational = false;
        public bool IsOperational
        {
            get { return _IsOperational; }
            set { Set(nameof(IsOperational), ref _IsOperational, value); }
        }
    }
}