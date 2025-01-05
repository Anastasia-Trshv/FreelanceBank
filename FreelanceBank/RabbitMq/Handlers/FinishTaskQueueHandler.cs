

using FreelanceBank.RabbitMq.Contracts;
using FreelanceBank.Services.Contracts;
using FreelanceBank.Services.Interfaces;

namespace FreelanceBank.RabbitMq.Handlers
{
    public class FinishTaskQueueHandler : MessageQueueConsumer<FinishTaskMessage>
    {
        private readonly IServiceProvider _services;
        public FinishTaskQueueHandler(IServiceProvider serviceProvider, IConfiguration config) : base(serviceProvider, config)
        {
            _services = serviceProvider;
        }

        protected override string QueueName => "FinishTaskQueue";

        protected async override Task Handle(FinishTaskMessage messageData)
        {
            using (IServiceScope _scope = _services.CreateScope())
            {
                IServiceProvider _provider = _scope.ServiceProvider;

                var userWalletService = _provider.GetRequiredService<IUserWalletService>();

                var contract = new PayForServiceContract(messageData.AuthorId, messageData.WorkerId, messageData.Price);
                await userWalletService.PayForService(contract);

                Console.WriteLine($"Task finished, salary ({messageData.Price}) paid to {messageData.WorkerId} from {messageData.AuthorId}");
            }
        }
    }
}
