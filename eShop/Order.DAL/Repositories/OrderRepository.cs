using DataAccess.Common;
using DataAccess.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Order.DAL.DataContext;
using Order.DAL.Entities;
using Order.DAL.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Order.DAL.Repositories
{
    public class OrderRepository : GenericRepository<Order.DAL.Entities.Order, OrderDataContext>, IOrderRepository
    {
        public OrderRepository(OrderDataContext context):base(context)
        {
            
        }

        public async Task<IEnumerable<Entities.Order>> GetOrders(int userId)
        {
            return await GetAll().Filter($"{{'data':[{{'PropertyName':'Name','Direction':'asc'}}]}}").ToListAsync<Entities.Order>();
        }
    }
}
