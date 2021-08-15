using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Notes.Application.Interfaces;
using Notes.Application.Wrappers;

namespace Notes.UseCases.Account.Queries.GetCurrentUserId
{
    public class GetCurrentUserIdQueryHandler: IRequestHandler<GetCurrentUserIdQuery,
        Response<GetCurrentUserIdViewModel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IJwtTokenService _jwtTokenService;
        
        public GetCurrentUserIdQueryHandler(
            IApplicationDbContext context, 
            ICurrentUserService currentUserService,
            IJwtTokenService jwtTokenService)
        {
            _context = context;
            _currentUserService = currentUserService;
            _jwtTokenService = jwtTokenService;
        }
        
        public async Task<Response<GetCurrentUserIdViewModel>> Handle(GetCurrentUserIdQuery request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var response = new Response<GetCurrentUserIdViewModel>(
                new GetCurrentUserIdViewModel()
                {
                    CurrentUserId = userId.ToString()
                });

            return response;
        }
    }
}