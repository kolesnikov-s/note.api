using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Application.Wrappers;
using Notes.Domain;

namespace Notes.UseCases.Account.Queries.GetTokenByCodeAndPhoneNumber
{
    public class GetTokenByCodeAndPhoneNumberQueryHandler: IRequestHandler<
        GetTokenByCodeAndPhoneNumberQuery, Response<GetTokenByCodeAndPhoneNumberViewModel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IJwtTokenService _jwtTokenService;
        
        public GetTokenByCodeAndPhoneNumberQueryHandler(
            IApplicationDbContext context, 
            ICurrentUserService currentUserService,
            IJwtTokenService jwtTokenService)
        {
            _context = context;
            _currentUserService = currentUserService;
            _jwtTokenService = jwtTokenService;
        }
        
        public async Task<Response<GetTokenByCodeAndPhoneNumberViewModel>> Handle(GetTokenByCodeAndPhoneNumberQuery request, CancellationToken cancellationToken)
        {
            bool isConfirmCode = request.Code == 1131;

            if (!isConfirmCode)
                return new Response<GetTokenByCodeAndPhoneNumberViewModel>("Неверный код из смс.");

            var identity = await GetIdentity(request.PhoneNumber);

            var encodedJwt = _jwtTokenService.Generate(identity);

            var response = new Response<GetTokenByCodeAndPhoneNumberViewModel>(new GetTokenByCodeAndPhoneNumberViewModel()
            {
                Username = identity.Name,
                AccessToken = encodedJwt
            });

            return response;
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