using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace FreelanceBank.RabbitMq
{
    public class RabbitMqService 
    {
        //private readonly RabbitMqMediator _mediator;

        //public RabbitMqService(RabbitMqMediator mediator)
        //{
        //    _mediator = mediator;
        //}
        private readonly IConfiguration _config;
        public RabbitMqService(IConfiguration configuration)
        {
            _config = configuration;
        }


        
    }
}
