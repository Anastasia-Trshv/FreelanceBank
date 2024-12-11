using System.ComponentModel.DataAnnotations.Schema;

namespace FreelanceBank.Database.Entities
{
    public class UserWallet
    {
        public long Id { get; set; }

        [Column(TypeName = "money")]
        public decimal Balance { get; set; }

        [Column(TypeName = "money")]
        public decimal FreezeBalance { get; set; }
    }
}
