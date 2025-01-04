using FreelanceBank.Database.Repository.Interfaces;
using FreelanceBank.Models;
using FreelanceBank.RabbitMq;
using FreelanceBank.Services.Contracts;
using FreelanceBank.Services.Interfaces;

namespace FreelanceBank.Services
{
    public class UserWalletService : IUserWalletService
    {
        private readonly IUserWalletRepository _userWalletRepository;
        public UserWalletService(IUserWalletRepository walletRepository) 
        {
            _userWalletRepository = walletRepository;
        }


        private async void HandleCreateWalletEvent(object sender, string message)
        {
            var userId = long.Parse(message);
            await CreateWallet(userId);
        }
        public async Task<UserWalletModel> CreateWallet(long id)
        {
            return await _userWalletRepository.CreateWallet(id);
        }

        public async Task<bool> FreezeMoney(long id, decimal money)
        {
           return await _userWalletRepository.FreezeMoney(id, money);
        }

        public async Task<bool> UnfreezeMoney(long id, decimal money)
        {
            return await _userWalletRepository.UnfreezeMoney(id, money);
        }

        public async Task<UserWalletModel> GetUserWallet(long id)
        {
            return await _userWalletRepository.GetUserWallet(id);
        }

        public async Task PayForService(PayForServiceContract contract)
        {
            await _userWalletRepository.PayForService(contract.AuthorId, contract.WorkerId, contract.Amount);
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
