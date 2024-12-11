using FreelanceBank.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace FreelanceBank.Database.Context
{
    public class FreelanceBankDbContext : DbContext
    {
        private readonly string _string;
        public FreelanceBankDbContext()
        {
        }
        public FreelanceBankDbContext(IConfiguration config)
        {
            _string = config["PostgreSQL : ConnectionString"];
        }

        public virtual DbSet<UserWallet> UserWallets { get; set; }
        public virtual DbSet<FreelanceWallet> FreelanceWallets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(_string);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FreelanceWallet>(entity =>
            {
                entity.HasData(new FreelanceWallet { Id = 1, Balance = 100 });
            });
        }
    }
}
