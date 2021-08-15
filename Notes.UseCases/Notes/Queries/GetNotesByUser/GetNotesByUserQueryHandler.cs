using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Application.Wrappers;
using Notes.Domain;

namespace Notes.UseCases.Notes.Queries.GetNotesByUser
{
    public class GetNotesByUserQueryHandler: IRequestHandler<GetNotesByUserQuery, 
        Response<IEnumerable<GetNotesByUserViewModel>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        
        public GetNotesByUserQueryHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Note, GetNotesByUserViewModel>();
            });

            _context = context;
            _mapper = config.CreateMapper();
            _currentUserService = currentUserService;
        }
        
        public async Task<Response<IEnumerable<GetNotesByUserViewModel>>> Handle(GetNotesByUserQuery request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            
            var notes = await _context.Notes
                .Where(n => n.UserId == userId)
                .ToListAsync(cancellationToken: cancellationToken);

            var response = new Response<IEnumerable<GetNotesByUserViewModel>>(
                _mapper.Map<IEnumerable<GetNotesByUserViewModel>>(notes));

            return response;
        }
    }
}