using FreelanceBank.Models;

namespace FreelanceBank.Database.Repository.Interfaces
{
    public interface IUserWalletRepository
    {
        Task<UserWalletModel> GetUserWallet(long id);
        Task ReplenishAccount(long id, decimal money);
        Task<bool> FreezeMoney(long id, decimal money);
        Task<bool> UnfreezeMoney(long id, decimal money);
        Task PayForService(long authorId, long workerId, decimal amount);
        Task<bool> WithdrawFromAccount(long id, decimal amount);
        Task<UserWalletModel> CreateWallet(long id);
    }
}
