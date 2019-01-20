using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using OracleNotes.Data.Commands.Note;
using OracleNotes.Data.Database;
using OracleNotes.Data.Models;
using OracleNotes.Data.Services.Interfaces;
using OracleNotes.Extensions.Exceptions;

namespace OracleNotes.Data.Services
{
    public class NoteService : INoteService
    {
        private readonly NoteContext _context;

        public NoteService(NoteContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CreateNoteCommand command)
        {
            if (string.IsNullOrEmpty(command.Title) || string.IsNullOrEmpty(command.Text))
            {
                throw new InternalSystemException("Title and note content can't be empty.");
            }

            var query = $"INSERT INTO \"Notes\" (\"Title\", \"Text\") VALUES ('{command.Title}', '{command.Text}');";
            await _context.Database.ExecuteSqlCommandAsync(query);
        }

        public async Task DeleteAsync(int id)
        {
            if (id <=0)
            {
                throw new InternalSystemException("Id must be greater than zero.");
            }

            var query = $"DELETE FROM \"Notes\" WHERE \"Id\" = {id};";
            await _context.Database.ExecuteSqlCommandAsync(query);
        }

        public IEnumerable<Note> GetAll()
            => _context.Notes.FromSql($"SELECT \"Id\", \"Title\", \"Text\" FROM \"Notes\";").AsEnumerable();
    }
}
