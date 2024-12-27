namespace FreelanceBank.Contracts.Responses
{
    public record UserWalletResponse
    (
        long Id,
        decimal Balance,
        decimal FreezeBalance
    );
}
