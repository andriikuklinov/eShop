using AutoMapper;
using Discount.BLL.DTO;
using Discount.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.BLL.MappingProfile
{
    public class BLLMappingProfile: Profile
    {
        public BLLMappingProfile()
        {
            CreateMap<Coupon, CouponDTO>();
            CreateMap<CouponDTO, Coupon>();
        }
    }
}
