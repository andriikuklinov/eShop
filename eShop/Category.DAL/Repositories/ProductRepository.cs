using Catalog.DAL.DataContext;
using Catalog.DAL.Entities;
using Catalog.DAL.Repositories.Contract;
using DataAccess.Common;
using DataAccess.Common.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DAL.Repositories
{
    public class ProductRepository : GenericRepository<Product, CatalogDataContext>, IProductRepository
    {
        public ProductRepository(CatalogDataContext context):base(context)
        {
            
        }
    }
}
