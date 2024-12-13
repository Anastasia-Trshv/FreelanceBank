using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using FreelanceBank.Abstractions.Services;
using Microsoft.Extensions.DependencyInjection;
using FreelanceBank.Services;
using FreelanceDB.RabbitMQ;
using Newtonsoft.Json;

namespace FreelanceBank.RabbitMq
{
    public class RabbitMqService : IRabbitMqService
    {
       
        public RabbitMqService()
        {
           
        }
        public async void SubscribeToCreateUserQueue()
        {
            var factory = new ConnectionFactory() { Uri = new Uri("amqps://lzpoyxzx:zHSe2yBq-j1eaCjF8S6ztpMg0Y_D2xg_@dog.lmq.cloudamqp.com/lzpoyxzx") };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: "CreateUserQueue", durable: false, exclusive: false, autoDelete: false,
                arguments: null);

            Console.WriteLine(" [*] Waiting for messages.");

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($" [x] Received {message}");
              //  using (var scope = _serviceProvider.CreateScope())//создание скоупа для передачи transient UserWalletService в этот singlton middleware
               // {
               //     var _userWalletService = scope.ServiceProvider.GetRequiredService<UserWalletService>();
                    //_userWalletService.CreateWallet(long.Parse(message));
                    return Task.CompletedTask;
                //}
            };

            await channel.BasicConsumeAsync("CreateUserQueue", autoAck: true, consumer: consumer);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }

        public async void SubscribeToCreateTaskQueue()
        {
            var factory = new ConnectionFactory() { Uri = new Uri("amqps://lzpoyxzx:zHSe2yBq-j1eaCjF8S6ztpMg0Y_D2xg_@dog.lmq.cloudamqp.com/lzpoyxzx") };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: "CreateTaskQueue", durable: false, exclusive: false, autoDelete: false,
                arguments: null);

            Console.WriteLine(" [*] Waiting for messages.");

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var messageObject = JsonConvert.DeserializeObject<CreateTaskRabbitMqModel>(message);
                Console.WriteLine($" [x] Received {message}");
                
                return Task.CompletedTask;
                
            };

            await channel.BasicConsumeAsync("CreateTaskQueue", autoAck: true, consumer: consumer);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
