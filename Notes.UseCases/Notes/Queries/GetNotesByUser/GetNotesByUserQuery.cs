using System.Collections.Generic;
using MediatR;
using Notes.Application.Wrappers;

namespace Notes.UseCases.Notes.Queries.GetNotesByUser
{
    public class GetNotesByUserIdQuery: IRequest<Response<IEnumerable<GetNotesByUserIdViewModel>>>
    {
        // public Guid UserId { get; set; }
    }
}