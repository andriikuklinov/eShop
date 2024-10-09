using AutoMapper;
using Catalog.API.Models;
using Catalog.BLL.DTO;
using Catalog.BLL.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(string? filter, string? orderBy, int? page, int? pageSize)
        {
            try
            {
                var products = _mapper.Map<IEnumerable<ProductDTO>, IEnumerable<ProductModel>>(
                    await _productService.GetProducts(filter, orderBy, page, pageSize)
                );
                return Ok(new ApiResponse<IEnumerable<ProductModel>>(products));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
