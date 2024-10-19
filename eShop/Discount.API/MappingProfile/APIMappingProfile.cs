using AutoMapper;
using Discount.API.Models;
using Discount.BLL.DTO;

namespace Discount.API.MappingProfile
{
    public class APIMappingProfile: Profile
    {
        public APIMappingProfile()
        {
            CreateMap<CouponDTO, CouponModel>();
            CreateMap<CouponModel, CouponDTO>();
        }
    }
}
