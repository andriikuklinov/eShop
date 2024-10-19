using AutoMapper;
using Discount.BLL.DTO;
using Discount.BLL.Services.Contract;
using Discount.DAL.Entities;
using Discount.DAL.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.BLL.Services
{
    public class CouponService : ICouponService
    {
        private readonly IMapper _mapper;
        private readonly ICouponRepository _couponRepository;

        public CouponService(IMapper mapper, ICouponRepository couponRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this._couponRepository = couponRepository ?? throw new ArgumentNullException(nameof(couponRepository));
        }

        public async Task<CouponDTO> CreateDiscount(CouponDTO coupon)
        {
            var result = await _couponRepository.CreateDiscount(_mapper.Map<Coupon>(coupon));
            return _mapper.Map<CouponDTO>(result);
        }

        public async Task<CouponDTO> DeleteDiscount(CouponDTO coupon)
        {
            var result = await _couponRepository.DeleteDiscount(_mapper.Map<Coupon>(coupon));
            return _mapper.Map<CouponDTO>(result);
        }

        public async Task<CouponDTO> GetDiscount(int productId)
        {
            return _mapper.Map<CouponDTO>(await _couponRepository.GetDiscount(productId));
        }

        public async Task<CouponDTO> UpdateDiscount(CouponDTO coupon)
        {
            var result = await _couponRepository.UpdateDiscount(_mapper.Map<Coupon>(coupon));
            return _mapper.Map<CouponDTO>(result);
        }
    }
}
