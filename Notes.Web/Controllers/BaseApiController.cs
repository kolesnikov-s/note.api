using System;
using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Notes.Web.Controllers
{
    [Route("")]
    // [Authorize]
    [ApiController]
    public class BaseApiController: ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        
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