using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Notes.Application.Interfaces;
using Notes.Application.Wrappers;
using Notes.Domain;
using Notes.UseCases.Notes.Queries.GetNotesByUser;

namespace Notes.UseCases.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler: IRequestHandler<CreateNoteCommand, Response<Guid>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        
        public CreateNoteCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }
        
        public async Task<Response<Guid>> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            
            var note = new Note()
            {
                Name = request.Name,
                Text = request.Text,
                DateUpdated = DateTime.UtcNow,
                UserId = userId
            };
        
            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();
        
            var response = new Response<Guid>(note.Id);

            return response;
        }
    }
}