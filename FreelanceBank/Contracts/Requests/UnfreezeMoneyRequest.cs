namespace FreelanceBank.Contracts.Requests
{
    public record class UnfreezeMoneyRequest
   (
        long Id,
        decimal Money
    );
}
