namespace FreelanceBank.Contracts.Requests
{
    public record ReplenishAccountRequest
    (
        long Id,
        decimal Money
    );
}
