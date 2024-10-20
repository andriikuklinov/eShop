using AutoMapper;
using Basket.BLL.DTO;
using Basket.BLL.Services.Contract;
using Basket.DAL.Entities;
using Basket.DAL.Repositories.Contract;
using EventBus.Messages.Common.Events;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.BLL.Services
{
    public class ShoppingCartService:IShoppingCartService
    {
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartService(IMapper mapper, IPublishEndpoint publishEndpoint, IShoppingCartRepository shoppingCartRepository)
        {
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task DeleteShoppingCart(string userName)
        {
            await _shoppingCartRepository.DeleteShoppingCart(userName);
        }

        public async Task<ShoppingCart?> GetShoppingCart(string userName)
        {
            return await _shoppingCartRepository.GetShoppingCart(userName);
        }

        public async Task<ShoppingCart?> UpdateShoppingCart(ShoppingCart cart)
        {
            return await _shoppingCartRepository.UpdateShoppingCart(cart);
        }

        public async Task Checkout(CheckoutDTO checkoutDto)
        {
            var shoppingCart = await _shoppingCartRepository.GetShoppingCart(checkoutDto.UserName);
            if (shoppingCart == null)
                throw new NullReferenceException("Can`t find shoping cart.");
            var eventMessage = _mapper.Map<BasketCheckoutEvent>(checkoutDto);
            eventMessage.TotalPrice = shoppingCart.TotalPrice;
            //Send checkout event to RabbitMQ
            await _publishEndpoint.Publish(eventMessage);
            //Remove existing shopping cart
            await _shoppingCartRepository.DeleteShoppingCart(shoppingCart.UserName);
        }
    }
}
