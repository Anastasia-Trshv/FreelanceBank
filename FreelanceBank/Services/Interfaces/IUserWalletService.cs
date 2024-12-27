using FreelanceBank.Models;
using FreelanceBank.Services.Contracts;

namespace FreelanceBank.Services.Interfaces
{
    public interface IUserWalletService
    {
        Task<UserWalletModel> GetUserWallet(long id);
        Task ReplenishAccount(long id, decimal money);
        Task<bool> FreezeMoney(long id, decimal money);
        Task<bool> UnfreezeMoney(long id, decimal money);
        Task PayForService(PayForServiceContract contract);
        Task<bool> WithdrawFromAccount(long id, decimal amount);
        Task<UserWalletModel> CreateWallet(long id);
    }
}
