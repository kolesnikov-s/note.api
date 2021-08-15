using System;
using MediatR;
using Notes.Application.Wrappers;

namespace Notes.UseCases.Notes.Commands.CreateNote
{
    public class CreateNoteCommand: IRequest<Response<Guid>>
    {
        public string Name { get; set; }
        public string Text { get; set; }
    }
}