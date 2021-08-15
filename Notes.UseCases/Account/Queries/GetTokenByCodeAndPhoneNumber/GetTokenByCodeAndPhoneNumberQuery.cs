using MediatR;
using Notes.Application.Wrappers;

namespace Notes.UseCases.Account.Queries.GetTokenByCodeAndPhoneNumber
{
    public class GetTokenByCodeAndPhoneNumberQuery: IRequest<Response<GetTokenByCodeAndPhoneNumberViewModel>>
    {
        public string PhoneNumber { get; set; }
        public int Code { get; set; }
    }
}