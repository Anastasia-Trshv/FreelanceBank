
using FreelanceBank.Services;

namespace FreelanceBank.RabbitMq
{
    public class MessageQueueConsumer : IHostedService
    {
        private readonly IRabbitMqService _rabbitMqService;
        

        public MessageQueueConsumer( IServiceProvider serviceProvider, IRabbitMqService rabbitMqService)
        {
            
            _rabbitMqService = rabbitMqService;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            
                _rabbitMqService.SubscribeToCreateUserQueue();
                _rabbitMqService.SubscribeToCreateTaskQueue();
            
            
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
