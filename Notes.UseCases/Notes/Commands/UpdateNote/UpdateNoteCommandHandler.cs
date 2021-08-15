using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Application.Wrappers;
using Notes.Domain;
using Notes.UseCases.Notes.Queries.GetNotesByUser;

namespace Notes.UseCases.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler: IRequestHandler<UpdateNoteCommand,
        Response<Guid>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        
        public UpdateNoteCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }
        
        public async Task<Response<Guid>> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == request.Id);

            if (note == null)
                return new Response<Guid>("Not Found");
        
            note.Name = request.Name;
            note.Text = request.Text;
            note.DateUpdated = DateTime.UtcNow;
        
            await _context.SaveChangesAsync();
        
            var response = new Response<Guid>(note.Id);

            return response;
        }
    }
}