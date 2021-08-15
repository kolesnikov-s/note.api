using MediatR;
using Notes.Application.Wrappers;

namespace Notes.UseCases.Users.Queries.GetCurrentUser
{
    public class GetCurrentUserQuery: IRequest<Response<GetCurrentUserViewModel>>
    {
        
    }
}