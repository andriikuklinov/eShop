using Discount.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.DAL.Repositories.Contract
{
    public interface ICouponRepository
    {
        Task<Coupon> GetDiscount(int productId);
        Task<Coupon> CreateDiscount(Coupon coupon);
        Task<Coupon> UpdateDiscount(Coupon coupon);
        Task<Coupon> DeleteDiscount(Coupon coupon);
    }
}
