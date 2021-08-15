using MediatR;
using Notes.Application.Wrappers;

namespace Notes.UseCases.Account.Queries.GetCurrentUserId
{
    public class GetCurrentUserIdQuery: IRequest<Response<GetCurrentUserIdViewModel>>
    {
        
    }
}