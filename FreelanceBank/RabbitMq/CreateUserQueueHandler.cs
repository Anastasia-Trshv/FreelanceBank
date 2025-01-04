using FreelanceBank.Services;
using FreelanceBank.Services.Interfaces;

namespace FreelanceBank.RabbitMq
{
    public class CreateUserQueueHandler : MessageQueueConsumer<int>
    {


        private readonly IServiceProvider _services;
        public CreateUserQueueHandler(IServiceProvider serviceProvider, IConfiguration config) : base(serviceProvider, config)
        {
            _services = serviceProvider;
        }

        protected override string QueueName => "CreateUserQueue";

        protected override async Task Handle(int messageData)
        {
            using (IServiceScope _scope = _services.CreateScope())
            {
                IServiceProvider _provider = _scope.ServiceProvider;

                var userWalletService = _provider.GetRequiredService<IUserWalletService>();

                await userWalletService.CreateWallet(messageData);


            }
        }
    }
}
