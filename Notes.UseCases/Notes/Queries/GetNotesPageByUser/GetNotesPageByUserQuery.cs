using System.Collections.Generic;
using MediatR;
using Notes.Application.Wrappers;

namespace Notes.UseCases.Notes.Queries.GetNotesPageByUser
{
    public class GetNotesPageByUserQuery: IRequest<PagedResponse<IEnumerable<GetNotesPageByUserViewModel>>>
    {
        public string SearchWords { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}