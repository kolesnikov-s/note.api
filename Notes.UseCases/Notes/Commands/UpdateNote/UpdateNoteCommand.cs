using System;
using MediatR;
using Notes.Application.Wrappers;

namespace Notes.UseCases.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommand: IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }
}