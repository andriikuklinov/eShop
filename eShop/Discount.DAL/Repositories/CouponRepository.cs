using DataAccess.Common;
using Discount.DAL.DataContext;
using Discount.DAL.Entities;
using Discount.DAL.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.DAL.Repositories
{
    public class CouponRepository: GenericRepository<Coupon, DiscountDataContext>, ICouponRepository
    {
        public CouponRepository(DiscountDataContext context):base(context)
        {
                      
        }

        public async Task<Coupon> CreateDiscount(Coupon coupon)
        {
            return await AddAsync(coupon);
        }

        public async Task<Coupon> DeleteDiscount(Coupon coupon)
        {
            return await DeleteAsync(coupon);
        }

        public async Task<Coupon> GetDiscount(int productId)
        {
            return await GetSingleAsync(_=>_.ProductId == productId);
        }

        public async Task<Coupon> UpdateDiscount(Coupon coupon)
        {
            return await UpdateAsync(coupon);
        }
    }
}
