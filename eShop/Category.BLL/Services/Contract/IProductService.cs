using Catalog.BLL.DTO;
using Catalog.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.BLL.Services.Contract
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts(string filter, string orderBy, int? page, int? pageSize);
    }
}
