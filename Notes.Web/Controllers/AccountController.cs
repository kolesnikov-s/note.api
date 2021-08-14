using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Notes.Application.Interfaces;
using Notes.Application.Wrappers;
using Notes.Database.PostgreSQL;
using Notes.Domain;
using Notes.Web.Models;
using Notes.Web.Options;

namespace Notes.Web.Controllers
{
    public class AccountController: BaseApiController
    {
    // {
    private readonly IApplicationDbContext _context;
    
    public AccountController(IApplicationDbContext context)
    {
        _context = context;
    }
    //     
    //     /// <summary>
    //     /// Получить идентификатор текущего пользователя.
    //     /// </summary>
    //     /// <returns></returns>
    //     [Authorize]
    //     [HttpGet, Route("account")]
    //     public async Task<IActionResult> Authentication()
    //     {
    //         var response = new Response<Guid>(GetCurrentUserId());
    //         
    //         return Ok(response);
    //     }
    //
    //     /// <summary>
    //     /// Отправить СМС с кодом подтверждения на телефон.
    //     /// </summary>
    //     /// <param name="phoneNumber">Номер телефона</param>
    //     /// <returns></returns>
    //     [AllowAnonymous]
    //     [HttpGet, Route("account/send-code")]
    //     public async Task<IActionResult> SendSms(int phoneNumber)
    //     {
    //         return Ok();
    //     }
    //
    /// <summary>
    /// Подтвердить номер телефона и получить токен.
    /// </summary>
    /// <param name="phoneNumber">Номер телефона</param>
    /// <param name="code">Код из СМС</param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpGet, Route("account/confirm-code")]
    public async Task<IActionResult> SendSms(string phoneNumber, int code)
    {
        bool isConfirmCode = code == 1131;
    
        if (!isConfirmCode)
        {
            return BadRequest(); // new Response<string>("Неверный код из смс.")
        }
    
        var identity = await GetIdentity(phoneNumber);
    
        var now = DateTime.UtcNow;
        
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            notBefore: now,
            claims: identity.Claims,
            expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
    
        var response = new Response<TokenViewModel>(new TokenViewModel()
        {
            Username = identity.Name,
            AccessToken = encodedJwt
        });
    
        return Ok(response);
    }
    
    
        private async Task<ClaimsIdentity> GetIdentity(string phoneNumber)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Phone == phoneNumber);
    
            if (user == null)
            {
                user = new User()
                {
                    Id = Guid.NewGuid(),
                    Phone = phoneNumber,
                };
                
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
                
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Phone),
                new Claim("Id", user.Id.ToString())
            };
            
            var claimsIdentity = new ClaimsIdentity(
                claims, "Token", 
                ClaimsIdentity.DefaultNameClaimType, 
                ClaimsIdentity.DefaultRoleClaimType);
            
            return claimsIdentity;
        }
    }
}