using AutoMapper;
using Order.BLL.DTO;
using Order.BLL.Services.Contract;
using Order.DAL.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.Services
{
    public class OrderService: IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task<IEnumerable<OrderDTO>> GetUserOrders(int userId)
        {
            var orders = await _orderRepository.GetOrders(userId);
            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }
    }
}
