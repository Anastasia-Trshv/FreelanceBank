namespace FreelanceBank.Services.Contracts
{
    public record PayForServiceContract
    (
        long AuthorId,
        long WorkerId,
        decimal Amount
        );
}
