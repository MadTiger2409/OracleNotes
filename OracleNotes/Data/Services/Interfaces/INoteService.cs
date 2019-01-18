using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OracleNotes.Data.Commands.Note;
using OracleNotes.Data.Models.DbQueries;

namespace OracleNotes.Data.Services.Interfaces
{
    public interface INoteService
    {
        Task AddAsync(CreateNoteCommand command);
        IEnumerable<NoteQuery> GetAll();
    }
}
