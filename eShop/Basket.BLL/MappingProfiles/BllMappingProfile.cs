using AutoMapper;
using Basket.BLL.DTO;
using EventBus.Messages.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.BLL.MappingProfiles
{
    public class BllMappingProfile:Profile
    {
        public BllMappingProfile()
        {
            CreateMap<CheckoutDTO, BasketCheckoutEvent>();
        }
    }
}
