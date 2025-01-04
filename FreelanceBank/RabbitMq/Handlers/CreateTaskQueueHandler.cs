using FreelanceBank.RabbitMq.Contracts;
using FreelanceBank.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.BearerToken;

namespace FreelanceBank.RabbitMq.Handlers
{
    public class CreateTaskQueueHandler : MessageQueueConsumer<CreateTaskMessage>
    {
        private readonly IServiceProvider _services;
        public CreateTaskQueueHandler(IServiceProvider serviceProvider, IConfiguration config) : base(serviceProvider, config)
        {
            _services = serviceProvider;
        }

        protected override string QueueName => "CreateTaskQueue";

        protected async override Task Handle(CreateTaskMessage messageData)
        {
            using (IServiceScope _scope = _services.CreateScope())
            {
                IServiceProvider _provider = _scope.ServiceProvider;

                var userWalletService = _provider.GetRequiredService<IUserWalletService>();

                await userWalletService.FreezeMoney(messageData.Id, messageData.Price);
                Console.WriteLine("Task created, money freezed");

            }
        }
    }
}
