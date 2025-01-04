namespace FreelanceBank.RabbitMq.Contracts
{
    public record CreateTaskMessage
    (
        long Id,
        decimal Price
        );
}
