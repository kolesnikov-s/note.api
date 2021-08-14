using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Notes.Application.Wrappers;

namespace Notes.UseCases.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler: IRequestHandler<CreateNoteCommand, Response<Guid>>
    {
        public async Task<Response<Guid>> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}