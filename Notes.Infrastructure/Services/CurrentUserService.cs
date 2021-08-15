using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Notes.Application.Interfaces;

namespace Notes.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid UserId
        {
            get
            {
                var id = _httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == "Id")?.Value;
                Guid.TryParse(id, out Guid userId);
                return userId;
            }
        } 
    }
}