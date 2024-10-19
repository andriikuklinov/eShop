using AutoMapper;
using Order.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.MappingProfile
{
    public class BllMappingProfile: Profile
    {
        public BllMappingProfile()
        {
            CreateMap<Order.DAL.Entities.Order, OrderDTO>();
            CreateMap<Order.DAL.Entities.OrderItem, OrderItemDTO>();
        }
    }
}
