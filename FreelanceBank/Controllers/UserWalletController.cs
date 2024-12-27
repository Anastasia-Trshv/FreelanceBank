using FreelanceBank.Contracts.Requests;
using FreelanceBank.Contracts.Responses;
using FreelanceBank.Models;
using FreelanceBank.Services.Contracts;
using FreelanceBank.Services.Interfaces;
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

        /// <summary>
        /// Получение кошелька пользователя
        /// </summary>
        /// <response code="200">Успешно</response>
        /// <response code="404">Кошелек не существует</response>
        [HttpGet]
        public async Task<ActionResult<UserWalletResponse>> GetUserWallet(UserWalletResponse resp)
        {
            var wallet = await _userWalletService.GetUserWallet(resp.Id);
            if (wallet.Id == 0) 
            {
                return NotFound();
            }
            return Ok(Convert(wallet));
        }

        /// <summary>
        /// Пополнение счета
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> ReplenishAccount(ReplenishAccountRequest request)
        {
            await _userWalletService.ReplenishAccount(request.Id, request.Money);
            return Ok();
        }

        /// <summary>
        /// Заморозка средств
        /// </summary>
        /// <response code="200">Сумма заморожена</response>
        /// <response code="400">Желаемая сумма заморозки превышает сумму на счету</response>
        [HttpPut]
        public async Task<ActionResult> FreezeMoney(FreezeMoneyRequest request)
        {
            var result = await _userWalletService.FreezeMoney(request.Id, request.Money);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Недостаточно средств");
            }
        }

        /// <summary>
        /// Разморозка средств
        /// </summary>
        /// <response code="200">Сумма разморожена</response>
        /// <response code="400">Желаемая сумма разморозки превышает замороженную сумму на счету</response>
        [HttpPut]
        public async Task<ActionResult> UnfreezeMoney(UnfreezeMoneyRequest request)
        {
            var result = await _userWalletService.UnfreezeMoney(request.Id, request.Money);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Запрошенная для разморозки сумма превышает замороженную сумму кошелька");
            }
        }

        /// <summary>
        /// Перевести замороженную сумму с кошелька заказчика на кошелек исполнителя
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> PayForService(PayForServiceRequest request)
        {
            PayForServiceContract payForServiceContract = new PayForServiceContract(request.AuthorId, request.WorkerId, request.Amount);
            await _userWalletService.PayForService(payForServiceContract);
            return Ok();
        }

        /// <summary>
        /// Снять средства со счета
        /// </summary>
        /// <response code="200">Успешно</response>
        /// <response code="400">На счету недостаточно средств либо они заморожены</response>
        [HttpPut]
        public async Task<ActionResult> WithdrawFromAccount(WirhdrawFromAccountRequest request)
        {
            var result = await _userWalletService.WithdrawFromAccount(request.Id, request.Amount);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest("На счету недостаточно средств либо они заморожены");
            }
        }
        /// <summary>
        /// Создание кошелька
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<UserWalletResponse>> CreateWallet(CreateWalletRequest request)
        {
            var wallet = await _userWalletService.CreateWallet(request.Id); 
            return Ok(Convert(wallet));
        }

        [NonAction]
        public UserWalletResponse Convert(UserWalletModel model)
        {
            return new UserWalletResponse(model.Id, model.Balance, model.FreezeBalance);
        }
    }
}
