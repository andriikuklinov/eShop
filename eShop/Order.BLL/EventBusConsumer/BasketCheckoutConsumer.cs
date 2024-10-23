using AutoMapper;
using EventBus.Messages.Common.Events;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.EventBusConsumer
{
    public class BasketCheckoutConsumer: IConsumer<BasketCheckoutEvent>
    {
        private readonly IMapper _mapper;

        public BasketCheckoutConsumer(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            
        }
    }
}
