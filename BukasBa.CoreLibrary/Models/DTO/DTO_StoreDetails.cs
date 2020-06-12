using BukasBa.CoreLibrary.Models.Interfaces;
using System;

namespace BukasBa.CoreLibrary.Models.DTO
{
    public class DTO_StoreDetails : IModelStoreDetails
    {
        public string ImagePath { get; set; }
        public string Id { get; set; }
        public string StoreName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public double Geo_Latitude { get; set; }
        public double Geo_Longitude { get; set; }
        public TimeSpan StoreOpen { get; set; }
        public TimeSpan StoreClosed { get; set; }
        public bool IsOpen { get; set; }
        public string OwnerId { get; set; }
        public bool IsOperational { get; set; }
    }
}