using FreelanceBank.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace FreelanceBank.Database.Context
{
    public class FreelanceBankDbContext : DbContext
    {
        public FreelanceBankDbContext()
        {
        }

        public virtual DbSet<UserWallet> UserWallets { get; set; }
        public virtual DbSet<FreelanceWallet> FreelanceWallets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=FreelanceBankDb;Username=developer;Password=developer");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FreelanceWallet>(entity =>
            {
                entity.HasData(new FreelanceWallet { Id = 1, Balance = 100 });
            });
        }
    }
}
