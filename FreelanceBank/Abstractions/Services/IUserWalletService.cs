﻿using FreelanceBank.Models;

namespace FreelanceBank.Abstractions.Services
{
    public interface IUserWalletService
    {
        Task<UserWalletModel> GetUserWallet(long id);
        Task ReplenishAccount(long id, decimal money);
        Task<bool> FreezeMoney(long id, decimal money);
        Task PayForService(long authorId, long workerId, decimal amount);
        Task<bool> WithdrawFromAccount(long id, decimal amount);
        Task<UserWalletModel> CreateWallet(long id);
    }
}
