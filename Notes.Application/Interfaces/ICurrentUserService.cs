using System;

namespace Notes.Application.Interfaces
{
    public interface ICurrentUserService
    {
        /// <summary>
        /// Идентификатор текущего пользователя.
        /// </summary>
        /// <returns></returns>
        Guid UserId { get; }
    }
}