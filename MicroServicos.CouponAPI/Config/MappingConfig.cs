using AutoMapper;
using MicroServicos.CouponAPI.Data.ValueObjects;
using MicroServicos.CouponAPI.Model;

namespace MicroServicos.CouponAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponVO, Coupon>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
