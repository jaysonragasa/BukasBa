using System;

namespace BukasBa.CoreLibrary.Models.Interfaces
{
    public interface IModelStoreDetails
    {
        string Address { get; set; }
        string ContactNumber { get; set; }
        double Geo_Latitude { get; set; }
        double Geo_Longitude { get; set; }
        string Id { get; set; }
        string ImagePath { get; set; }
        bool IsOpen { get; set; }
        TimeSpan StoreClosed { get; set; }
        string StoreName { get; set; }
        TimeSpan StoreOpen { get; set; }
        string OwnerId { get; set; }
        bool IsOperational { get; set; }
    }
}