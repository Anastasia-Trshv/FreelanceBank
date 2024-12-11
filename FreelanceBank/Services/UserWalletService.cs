using FreelanceBank.Abstractions.Repositories;
using FreelanceBank.Abstractions.Services;
using FreelanceBank.Models;

namespace FreelanceBank.Services
{
    public class UserWalletService : IUserWalletService
    {
        private readonly IUserWalletRepository _userWalletRepository;
        public UserWalletService(IUserWalletRepository walletRepository) 
        {
            _userWalletRepository = walletRepository;
        }
        public async Task<UserWalletModel> CreateWallet(long id)
        {
            return await _userWalletRepository.CreateWallet(id);
        }

        public async Task<bool> FreezeMoney(long id, decimal money)
        {
           return await _userWalletRepository.FreezeMoney(id, money);
        }

        public async Task<UserWalletModel> GetUserWallet(long id)
        {
            return await _userWalletRepository.GetUserWallet(id);
        }

        public async Task PayForService(long authorId, long workerId, decimal amount)
        {
            await _userWalletRepository.PayForService(authorId, workerId, amount);
        }

        public async Task ReplenishAccount(long id, decimal money)
        {
            await _userWalletRepository.ReplenishAccount(id, money);
        }

        public async Task<bool> WithdrawFromAccount(long id, decimal amount)
        {
            return await _userWalletRepository.WithdrawFromAccount(id, amount);
        }
    }
}
