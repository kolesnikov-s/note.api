using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notes.Controllers.Common;
using Notes.UseCases.Account.Queries.GetCurrentUserId;
using Notes.UseCases.Account.Queries.GetTokenByCodeAndPhoneNumber;

namespace Notes.Controllers
{
    public class AccountController : BaseApiController
    {
        /// <summary>
        /// Получить идентификатор текущего пользователя.
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet, Route("account")]
        public async Task<IActionResult> Authentication()
        {
            var response = await Mediator.Send(new GetCurrentUserIdQuery());
            
            return Ok(response);
        }
        
        /// <summary>
        /// Отправить СМС с кодом подтверждения на телефон.
        /// </summary>
        /// <param name="phoneNumber">Номер телефона</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost, Route("account/send-code")]
        public async Task<IActionResult> SendSms(int phoneNumber)
        {
            return Ok();
        }
        //
        /// <summary>
        /// Подтвердить номер телефона и получить токен.
        /// </summary>
        /// <param name="phoneNumber">Номер телефона</param>
        /// <param name="code">Код из СМС</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet, Route("account/confirm-code")]
        public async Task<IActionResult> ConfirmCodeAndGetToken(string phoneNumber, int code)
        {
            var response = await Mediator.Send(new GetTokenByCodeAndPhoneNumberQuery()
            {
                Code = code,
                PhoneNumber = phoneNumber
            });

            return Ok(response);
        }
    }
}