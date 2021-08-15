using System.Security.Claims;

namespace Notes.Application.Interfaces
{
    public interface IJwtTokenService
    {
        string Generate(ClaimsIdentity identity);
    }
}