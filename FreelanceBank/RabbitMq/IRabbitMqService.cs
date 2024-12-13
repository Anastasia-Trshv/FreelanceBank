namespace FreelanceBank.RabbitMq
{
    public interface IRabbitMqService
    {
        void SubscribeToCreateUserQueue();
        void SubscribeToCreateTaskQueue();
    }
}
