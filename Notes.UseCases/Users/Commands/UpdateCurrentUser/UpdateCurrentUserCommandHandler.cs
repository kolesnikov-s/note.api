using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Application.Wrappers;

namespace Notes.UseCases.Users.Commands.UpdateCurrentUser
{
    public class UpdateCurrentUserCommandHandler: IRequestHandler<UpdateCurrentUserCommand, Response<Guid>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        
        public UpdateCurrentUserCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        
        public async Task<Response<Guid>> Handle(UpdateCurrentUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == _currentUserService.UserId);

            if (request.Phone != null) user.Phone = request.Phone;
            if (request.Theme != null) user.Theme = request.Theme;
            if (request.Language != null) user.Language = request.Language;

            user.DateUpdated = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            var response = new Response<Guid>(user.Id);
            
            return response;
        }
    }
}