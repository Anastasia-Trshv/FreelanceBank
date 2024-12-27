namespace FreelanceBank.RabbitMq
{
    public class RabbitMqMediator
    {
        public event EventHandler<string> CreateWalletEvent;

        public void Notify(string message)
        {
            CreateWalletEvent?.Invoke(this, message);
        }
    }
}
