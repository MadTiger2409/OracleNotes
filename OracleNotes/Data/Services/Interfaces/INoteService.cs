using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OracleNotes.Data.Commands.Note;
using OracleNotes.Data.Models;

namespace OracleNotes.Data.Services.Interfaces
{
    public interface INoteService
    {
        IEnumerable<Note> GetAll();
        Note Get(int id);
        Task AddAsync(CreateNoteCommand command);
        Task DeleteAsync(int id);
        Task UpdateAsync(Note note);
    }
}
