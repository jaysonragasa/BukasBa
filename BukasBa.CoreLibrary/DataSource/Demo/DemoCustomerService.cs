using BukasBa.CoreLibrary.DataSource.Interfaces;
using BukasBa.CoreLibrary.Models.DTO;
using BukasBa.CoreLibrary.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BukasBa.CoreLibrary.DataSource.Demo
{
    public class DemoCustomerService : ICustomerService
    {
        Random r = new Random(DateTime.Now.Millisecond);

        public async Task<List<IModelStoreDetails>> GetAllFavoritesAsync()
        {
            List<IModelStoreDetails> stores = new List<IModelStoreDetails>();

            string[] storenames = "Kanor's Chicken|PAXAKA|kalaya|sarani|Tamiti|DHAKAM|samani|kexaka|teriya|kalano".Split('|');
            string[] address = "7633 Manor Station Street, Lakeland, FL 33801|9731 Marvon Street, Woodhaven, NY 11421|7273 White St., Twin Falls, ID 83301|497 Bradford St., Eden Prairie, MN 55347|1C State St., Windsor, CT 06095|3 Edgemont Street, Hollywood, FL 33020|667C Silver Spear Dr., Casselberry, FL 32707|73 Pin Oak Rd., Cumming, GA 30040|651 Newbridge Ave., King Of Prussia, PA 19406|628 Border Ave., West Warwick, RI 02893".Split('|');
            string[] cpnumber = "(342) 373-5271|(210) 474-5506|(213) 210-4137|(742) 946-4214|(476) 595-3294|(830) 763-9655|(771) 977-0497|(697) 428-3727|(438) 293-4816|(555) 557-6070".Split('|');

            for (int i = 0; i < storenames.Length; i++)
            {
                stores.Add(new DTO_StoreDetails()
                {
                    ImagePath = $"https://i.picsum.photos/id/{r.Next(1, 100)}/200/200.jpg",
                    StoreName = storenames[i],
                    Address = address[i],
                    ContactNumber = cpnumber[i],
                    StoreOpen = new TimeSpan(8, 0, 0),
                    StoreClosed = new TimeSpan(17, 0, 0),
                    Geo_Latitude = 9.81613,
                    Geo_Longitude = 151.84676,
                    IsOpen = r.Next(0, 50) > 25 ? true : false
                });
            }

            return stores;
        }
    }
}