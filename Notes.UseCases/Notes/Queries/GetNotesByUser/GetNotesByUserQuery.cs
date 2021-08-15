using System.Collections.Generic;
using MediatR;
using Notes.Application.Wrappers;

namespace Notes.UseCases.Notes.Queries.GetNotesByUser
{
    public class GetNotesByUserQuery: IRequest<Response<IEnumerable<GetNotesByUserViewModel>>>
    {
    }
}