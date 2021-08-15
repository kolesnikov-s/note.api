using System;

namespace Notes.UseCases.Notes.Queries.GetNotesByUser
{
    public class GetNotesByUserIdViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}