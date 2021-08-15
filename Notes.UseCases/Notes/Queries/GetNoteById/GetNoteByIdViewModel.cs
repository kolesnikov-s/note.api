using System;

namespace Notes.UseCases.Notes.Queries.GetNoteById
{
    public class GetNoteByIdViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}