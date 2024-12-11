using FreelanceBank.Abstractions.Services;
using FreelanceBank.Contracts;
using FreelanceBank.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceBank.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserWalletController : ControllerBase
    {
        private readonly IUserWalletService _userWalletService;
        public UserWalletController(IUserWalletService walletService)
        {
            _userWalletService = walletService;
        }
        [HttpGet]
        public async Task<ActionResult<UserWalletResponse>> GetUserWallet(long id)
        {
            var wallet = await _userWalletService.GetUserWallet(id);

            return Ok(Convert(wallet));
        }

        [HttpPut]
        public async Task<ActionResult> ReplenishAccount(long id, decimal money)
        {
            await _userWalletService.ReplenishAccount(id, money);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> FreezeMoney(long id, decimal money)
        {
            var result = await _userWalletService.FreezeMoney(id, money);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Недостаточно средств");
            }
        }
        [HttpPut]
        public async Task<ActionResult> PayForService(long authorId, long workerId, decimal amount)
        {
            await _userWalletService.PayForService(authorId, workerId, amount);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> WithdrawFromAccount(long id, decimal amount)
        {
            var result = await _userWalletService.WithdrawFromAccount(id, amount);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest("На счету недостаточно средств либо они заморожены");
            }
        }
        [HttpPost]
        public async Task<ActionResult<UserWalletResponse>> CreateWallet(long id)
        {
            var wallet = await _userWalletService.CreateWallet(id); 
            return Ok(Convert(wallet));
        }

        public UserWalletResponse Convert(UserWalletModel model)
        {
            return new UserWalletResponse(model.Id, model.Balance, model.FreezeBalance);
        }
    }
}
