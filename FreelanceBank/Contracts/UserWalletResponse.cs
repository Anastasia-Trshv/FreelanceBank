namespace FreelanceBank.Contracts
{
    public record UserWalletResponse
    (
        long Id,
        decimal Balance,
        decimal FreezeBalance
    );
}
