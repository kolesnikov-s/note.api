using System;

namespace Notes.UseCases.Notes.Queries.GetNotesByUser
{
    public class GetNotesByUserIdViewModel
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public Guid UserId { get; set; }
    }
}