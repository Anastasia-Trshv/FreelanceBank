namespace FreelanceBank.Contracts.Requests
{
    public record class WirhdrawFromAccountRequest
    (
        long Id,
        decimal Amount
    );
}
