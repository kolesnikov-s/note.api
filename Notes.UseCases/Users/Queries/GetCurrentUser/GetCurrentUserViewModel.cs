using System;

namespace Notes.UseCases.Users.Queries.GetCurrentUser
{
    public class GetCurrentUserViewModel
    {
        public Guid Id { get; set; }
        public string Phone { get; set; }
        public string Theme { get; set; }
        public string Language { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}