using Microsoft.EntityFrameworkCore;
using Notes.Domain;

namespace Notes.Database.PostgreSQL
{
    public class NotesDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        
        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options) { }
        public NotesDbContext() { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSnakeCaseNamingConvention();
        }
    }
}