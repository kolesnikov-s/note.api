using System;
using MediatR;
using Notes.Application.Wrappers;

namespace Notes.UseCases.Users.Commands.UpdateCurrentUser
{
    public class UpdateCurrentUserCommand: IRequest<Response<Guid>>
    {
        public string Phone { get; set; }
        public string Theme { get; set; }
        public string Language { get; set; }
    }
}