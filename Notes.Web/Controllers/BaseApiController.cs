using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Notes.Web.Controllers
{
    [Route("")]
    [Authorize]
    [ApiController]
    public class BaseApiController: ControllerBase
    {

        /// <summary>
        /// Получить идентификатор текущего пользователя.
        /// </summary>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        public Guid GetCurrentUserId()
        {
            var id = User?.Claims?.FirstOrDefault(c => c.Type == "Id")?.Value;

            Guid.TryParse(id, out Guid userId);
            
            return userId;
        }

        /// <summary>
        /// Получить номер телефона текущего пользователя.
        /// </summary>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        public string GetCurrentUserPhoneNumber()
        {
            return User?.Identity?.Name;
        }
    }
}