using Order.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.Services.Contract
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetUserOrders(int userId);
    }
}
