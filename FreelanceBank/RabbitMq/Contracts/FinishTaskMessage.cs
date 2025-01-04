namespace FreelanceBank.RabbitMq.Contracts
{
    public record FinishTaskMessage
    (
        long AuthorId,
        decimal Price,
        long WorkerId
    );
}
