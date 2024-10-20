using DataAccess.Common.Contract;
using Order.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.DAL.Repositories.Contract
{
    public interface IOrderRepository: IGenericRepository<Order.DAL.Entities.Order>
    {
        Task<IEnumerable<Order.DAL.Entities.Order>> GetOrders(int userId);
    }
}
