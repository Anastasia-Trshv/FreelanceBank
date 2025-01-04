
using FreelanceBank.Services;
using Microsoft.EntityFrameworkCore.Metadata;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;

namespace FreelanceBank.RabbitMq
{
    public abstract class MessageQueueConsumer<TMessage> : BackgroundService
    {
        
        private readonly IServiceProvider _services;
        private readonly IConfiguration _config;
        private RabbitMQ.Client.IModel _channel;
        private IConnection connection;
        protected abstract string QueueName { get; }


        public MessageQueueConsumer( IServiceProvider serviceProvider, IConfiguration config)
        {
            _services = serviceProvider;
            _config = config;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            var factory = new ConnectionFactory() { Uri = new Uri(_config["RabbitMQ: ConnectionString"]) };
            connection = factory.CreateConnection();
            _channel = connection.CreateModel();

            _channel.QueueDeclarePassive(QueueName);
            _channel.BasicQos(0, 1, false);

            return base.StartAsync(cancellationToken);
        }


        public async override Task StopAsync(CancellationToken cancellationToken)
        {
            await base.StopAsync(cancellationToken);
            connection.Close();
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //while (!stoppingToken.IsCancellationRequested)
            //{
            //    using (IServiceScope _scope = _services.CreateScope())
            //    {
            //        IServiceProvider _provider = _scope.ServiceProvider;
            //        try
            //        {
            //            await _rabbitMqService.SubscribeToCreateUserQueue();
            //            await _rabbitMqService.SubscribeToCreateTaskQueue();

            //        }
            //        finally
            //        {

            //        }
            //    }

            //}

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (bc, ea) =>
            {
                var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                var messageData = JsonSerializer.Deserialize<TMessage>(message);
                await Task.Run(async () => await Handle(messageData));
                _channel.BasicAck(ea.DeliveryTag, false);
            };
            
            _channel.BasicConsume(queue: QueueName, autoAck: false, consumer: consumer);
            await Task.CompletedTask;
        }

        abstract protected Task Handle(TMessage messageData);
    }
}
