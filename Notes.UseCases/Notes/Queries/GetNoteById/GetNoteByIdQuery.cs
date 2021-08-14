using System;
using MediatR;
using Notes.Application.Wrappers;

namespace Notes.UseCases.Notes.Queries.GetNoteById
{
    public class GetNoteByIdQuery: IRequest<Response<GetNoteByIdViewModel>>
    {
        public Guid NoteId { get; set; }
    }
}