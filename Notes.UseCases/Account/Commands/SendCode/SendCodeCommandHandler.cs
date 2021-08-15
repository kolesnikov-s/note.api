using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Notes.UseCases.Account.Commands.SendCode
{
    public class SendCodeCommandHandler: IRequestHandler<SendCodeCommand>
    {
        public async Task<Unit> Handle(SendCodeCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}