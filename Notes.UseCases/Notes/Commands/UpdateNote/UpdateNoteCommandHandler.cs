using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Notes.Application.Wrappers;

namespace Notes.UseCases.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler: IRequestHandler<UpdateNoteCommand,
        Response<Guid>>
    {
        public async Task<Response<Guid>> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}