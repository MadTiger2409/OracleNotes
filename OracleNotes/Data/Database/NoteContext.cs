using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OracleNotes.Data.Models;
using OracleNotes.Data.Models.DbQueries;

namespace OracleNotes.Data.Database
{
    public class NoteContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbQuery<NoteQuery> NotesQuery { get; set; }

        public NoteContext(DbContextOptions<NoteContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                    .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Note>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
