using Catalog.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DAL.Repositories.Contract
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts(string filter, string orderBy, int? page, int? pageSize);
    }
}
