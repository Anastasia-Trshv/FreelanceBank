namespace FreelanceBank.Contracts.Requests
{
    public record class FreezeMoneyRequest
    (
        long Id,
        decimal Money
    );
}
