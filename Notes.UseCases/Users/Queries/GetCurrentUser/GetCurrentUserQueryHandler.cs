using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Application.Wrappers;
using Notes.Domain;
using Notes.UseCases.Notes.Queries.GetNotesByUser;

namespace Notes.UseCases.Users.Queries.GetCurrentUser
{
    public class GetCurrentUserQueryHandler: IRequestHandler<GetCurrentUserQuery, Response<GetCurrentUserViewModel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public GetCurrentUserQueryHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, GetCurrentUserViewModel>();
            });
            
            _mapper = config.CreateMapper();
            _context = context;
            _currentUserService = currentUserService;
        }
        
        public async Task<Response<GetCurrentUserViewModel>> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == _currentUserService.UserId);

            var response = new Response<GetCurrentUserViewModel>(
                _mapper.Map<GetCurrentUserViewModel>(user));

            return response;
        }
    }
}