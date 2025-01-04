

namespace FreelanceBank.RabbitMq
{
    public class CreateUserQueueHandler : MessageQueueConsumer<CreateUserQueueHandler>
    {
        public CreateUserQueueHandler(IServiceProvider serviceProvider, IRabbitMqService rabbitMqService) : base(serviceProvider, rabbitMqService)
        {
        }

        protected override string QueueName => throw new NotImplementedException();

        protected override Task Handle(CreateUserQueueHandler messageData)
        {
            throw new NotImplementedException();
        }
    }
}
