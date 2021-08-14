using System;
using MediatR;
using Notes.Application.Wrappers;

namespace Notes.UseCases.Notes.Commands.DeleteNoteById
{
    public class DeleteNoteByIdCommand: IRequest<Response<Guid>>
    {
        
    }
}