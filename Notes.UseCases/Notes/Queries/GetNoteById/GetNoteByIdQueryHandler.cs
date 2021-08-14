using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Notes.Application.Wrappers;

namespace Notes.UseCases.Notes.Queries.GetNoteById
{
    public class GetNoteByIdQueryHandler: IRequestHandler<GetNoteByIdQuery,
        Response<GetNoteByIdViewModel>>
    {
        public async Task<Response<GetNoteByIdViewModel>> Handle(GetNoteByIdQuery request, CancellationToken cancellationToken)
        {
            return new Response<GetNoteByIdViewModel>();
        }
    }
}