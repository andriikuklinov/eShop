using Catalog.DAL.DataContext;
using Catalog.DAL.Entities;
using Catalog.DAL.Repositories.Contract;
using DataAccess.Common;
using DataAccess.Common.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Catalog.DAL.Repositories
{
    public class ProductRepository : GenericRepository<Product, CatalogDataContext>, IProductRepository
    {
        public ProductRepository(CatalogDataContext context):base(context)
        {
            
        }

        public async Task<IEnumerable<Product>> GetProducts(string filter, string orderBy, int? page, int? pageSize)
        {
            return await GetAll().Filter(filter).OrderBy(orderBy).Paginate(page, pageSize).ToListAsync<Product>();
        }
    }
}
