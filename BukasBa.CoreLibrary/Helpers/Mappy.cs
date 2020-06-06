using AutoMapper;
using BukasBa.CoreLibrary.Models;
using BukasBa.CoreLibrary.Models.Interfaces;
using System;

namespace BukasBa.CoreLibrary.Helpers
{
    public class Mappy
    {
		static Lazy<IMapper> _i => new Lazy<IMapper>(() =>
		{
			return Init();
		});

		public static IMapper I = _i.Value;

		public static MapperConfiguration Config = (MapperConfiguration)_i.Value.ConfigurationProvider;

		static IMapper Init()
		{
			var config = new MapperConfiguration(cfg => {
				cfg.CreateMap<IModelStoreDetails, Model_StoreDetails>();
			});

			return config.CreateMapper();
		}
	}
}