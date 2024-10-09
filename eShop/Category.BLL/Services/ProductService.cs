using AutoMapper;
using Catalog.BLL.DTO;
using Catalog.BLL.Services.Contract;
using Catalog.DAL.Entities;
using Catalog.DAL.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.BLL.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts(string filter, string orderBy, int? page, int? pageSize)
        {
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(
                await _repository.GetProducts(filter, orderBy, page, pageSize)
            );
        }
    }
}
