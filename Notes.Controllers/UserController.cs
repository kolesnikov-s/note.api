using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Notes.Controllers.Common;
using Notes.UseCases.Users.Commands.UpdateCurrentUser;
using Notes.UseCases.Users.Queries.GetCurrentUser;

namespace Notes.Controllers
{
    public class UserController : BaseApiController
    {
        /// <summary>
        /// Получить текущего пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("users/current")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var response = await Mediator.Send(new GetCurrentUserQuery());
            
            return Ok(response);
        }
        
        /// <summary>
        /// Обновить текущего пользователя
        /// </summary>
        /// <returns></returns>
        [HttpPut, Route("users/current")]
        public async Task<IActionResult> UpdateCurrentUser(UpdateCurrentUserCommand command)
        {
            var response = await Mediator.Send(command);
            
            return Ok(response);
        }
    }
}