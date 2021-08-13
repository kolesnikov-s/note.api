using System;
using Notes.Domain.Common;

namespace Notes.Domain
{
    public class Note: BaseEntity
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public Guid UserId { get; set; }
    }
}