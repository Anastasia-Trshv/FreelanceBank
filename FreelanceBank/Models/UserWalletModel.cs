namespace FreelanceBank.Models
{
    public class UserWalletModel
    {
        public long Id { get; set; }
        public decimal Balance { get; set; }
        public decimal FreezeBalance { get; set; }
    }
}
