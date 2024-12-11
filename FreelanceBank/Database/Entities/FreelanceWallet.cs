using System.ComponentModel.DataAnnotations.Schema;

namespace FreelanceBank.Database.Entities
{
    public class FreelanceWallet
    {
        public long Id { get; set; }

        [Column(TypeName = "money")]
        public decimal Balance { get; set; }
    }
}
