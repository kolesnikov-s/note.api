using System;
using MediatR;
using Notes.Application.Wrappers;

namespace Notes.UseCases.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommand: IRequest<Response<Guid>>
    {
        
    }
}