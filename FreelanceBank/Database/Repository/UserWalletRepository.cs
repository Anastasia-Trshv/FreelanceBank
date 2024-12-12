using FreelanceBank.Abstractions.Repositories;
using FreelanceBank.Database.Context;
using FreelanceBank.Database.Entities;
using FreelanceBank.Models;

namespace FreelanceBank.Database.Repository
{
    public class UserWalletRepository : IUserWalletRepository
    {
        private readonly decimal _commision = 0.95m;
        private readonly FreelanceBankDbContext _context;
        public UserWalletRepository(FreelanceBankDbContext context) 
        {
            _context = context;
        }
        public async Task<UserWalletModel> CreateWallet(long id)
        {
            UserWallet userWallet = new UserWallet { Id=id};
            _context.UserWallets.Add(userWallet);
            await _context.SaveChangesAsync();
            return Convert(userWallet);
        }

        public async Task<bool> FreezeMoney(long id, decimal money)
        {
            var wallet = await _context.UserWallets.FindAsync(id);
            if(wallet.Balance-wallet.FreezeBalance>=money) 
            {
                wallet.FreezeBalance += money;
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<UserWalletModel> GetUserWallet(long id)
        {
            var wallet = await _context.UserWallets.FindAsync(id);
            if(wallet == null)
            {
                return new UserWalletModel();
            }
            return Convert(wallet);
        }

        public async Task PayForService(long authorId, long workerId, decimal amount)
        {
            var customerWallet = await _context.UserWallets.FindAsync(authorId);
            var workerWallet = await _context.UserWallets.FindAsync(workerId);

            customerWallet.FreezeBalance -= amount;
            workerWallet.Balance += amount * _commision;//комиссия 
            var freelanceWallet = await _context.FreelanceWallets.FindAsync(1L);
            freelanceWallet.Balance += amount * (1 - _commision);

            await _context.SaveChangesAsync();
        }

        public async Task ReplenishAccount(long id, decimal money)
        {
            var wallet = await _context.UserWallets.FindAsync(id);
            wallet.Balance += money;
            await _context.SaveChangesAsync();
            
        }

        public async Task<bool> WithdrawFromAccount(long id, decimal amount)
        {
            var wallet = await _context.UserWallets.FindAsync(id);
            if (wallet.Balance - wallet.FreezeBalance >= amount)
            {
                wallet.Balance -= amount;
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }


        private UserWalletModel Convert(UserWallet wallet)
        {
            return new UserWalletModel { Id = wallet.Id, Balance = wallet.Balance, FreezeBalance = wallet.FreezeBalance };
        }
    }
}
