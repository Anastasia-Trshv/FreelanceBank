namespace FreelanceBank.Contracts.Requests
{
    public record class PayForServiceRequest
    (
        long AuthorId,
        long WorkerId,
        decimal Amount
    );
}
