using System.ComponentModel.DataAnnotations.Schema;

namespace FreelanceBank.Database.Entities
{
    public class UserWallet
    {
        public int Id { get; set; }

        [Column(TypeName = "money")]
        public decimal Balance { get; set; }

        [Column(TypeName = "money")]
        public decimal FreezeBalance { get; set; }
    }
}
