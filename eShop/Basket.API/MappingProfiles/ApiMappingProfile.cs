using AutoMapper;
using Basket.API.Models;
using Basket.BLL.DTO;
using EventBus.Messages.Common.Events;

namespace Basket.API.MappingProfiles
{
    public class ApiMappingProfile: Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<BasketCheckoutModel, CheckoutDTO>();
        }
    }
}
