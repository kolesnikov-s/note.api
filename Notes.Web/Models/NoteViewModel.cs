using System;

namespace Notes.Web.Models
{
    public class NoteViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }
}