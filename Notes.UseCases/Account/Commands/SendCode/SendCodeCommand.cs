using MediatR;
using Notes.Application.Wrappers;

namespace Notes.UseCases.Account.Commands.SendCode
{
    public class SendCodeCommand: IRequest
    {
        public string PhoneNumber { get; set; }
    }
}