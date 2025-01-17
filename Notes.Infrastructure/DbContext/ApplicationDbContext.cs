﻿using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Infrastructure.DbContext
{
    public class ApplicationDbContext: Microsoft.EntityFrameworkCore.DbContext, IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public ApplicationDbContext() { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSnakeCaseNamingConvention();
        }
    }
}