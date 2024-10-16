using AutoMapper;
using Order.API.Models;
using Order.BLL.DTO;

namespace Order.API.MappingProfile
{
    public class ApiMappingProfile: Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<OrderDTO, OrderModel>();
            CreateMap<OrderItemDTO, OrderItemModel>();
        }
    }
}
