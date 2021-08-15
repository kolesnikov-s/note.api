using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Application.Wrappers;
using Notes.Domain;

namespace Notes.UseCases.Notes.Queries.GetNoteById
{
    public class GetNoteByIdQueryHandler: IRequestHandler<GetNoteByIdQuery, Response<GetNoteByIdViewModel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        public GetNoteByIdQueryHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Note, GetNoteByIdViewModel>();
            });

            _context = context;
            _mapper = config.CreateMapper();
            _currentUserService = currentUserService;
        }
        public async Task<Response<GetNoteByIdViewModel>> Handle(GetNoteByIdQuery request, CancellationToken cancellationToken)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == request.NoteId);

            if (note == null)
                return new Response<GetNoteByIdViewModel>("Not Found");

            var response = new Response<GetNoteByIdViewModel>(_mapper.Map<GetNoteByIdViewModel>(note));

            return response;
        }
    }
}