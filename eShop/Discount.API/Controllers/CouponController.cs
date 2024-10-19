using AutoMapper;
using Discount.BLL.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Discount.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICouponService _couponService;

        public CouponController(IMapper mapper, ICouponService couponService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _couponService = couponService ?? throw new ArgumentNullException(nameof(couponService));
        }

        [HttpGet]
        public async Task<IActionResult> GetCoupon(int productId)
        {
            return Ok(await _couponService.GetDiscount(productId));
        }
    }
}
