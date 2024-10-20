using Discount.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.BLL.Services.Contract
{
    public interface ICouponService
    {
        Task<CouponDTO> GetDiscount(int productId);
        Task<CouponDTO> CreateDiscount(CouponDTO coupon);
        Task<CouponDTO> UpdateDiscount(CouponDTO coupon);
        Task<CouponDTO> DeleteDiscount(CouponDTO coupon);
    }
}
