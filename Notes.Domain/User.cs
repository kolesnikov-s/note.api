using System.Collections.Generic;
using Notes.Domain.Common;

namespace Notes.Domain
{
    public class User: BaseEntity
    {
        public string Phone { get; set; }
        
        public virtual ICollection<Note> Notes { get; set; }
    }
}