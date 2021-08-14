using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Notes.Application.Wrappers;

namespace Notes.UseCases.Notes.Commands.DeleteNoteById
{
    public class DeleteNoteByIdCommandHandler: IRequestHandler<DeleteNoteByIdCommand, Response<Guid>>
    {
        public Task<Response<Guid>> Handle(DeleteNoteByIdCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}