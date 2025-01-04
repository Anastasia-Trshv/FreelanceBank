namespace FreelanceBank.RabbitMq
{
    public interface IRabbitMqService
    {
        Task SubscribeToCreateUserQueue();
        Task SubscribeToCreateTaskQueue();
    }
}
