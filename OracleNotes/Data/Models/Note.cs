using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OracleNotes.Data.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public Note() { }

        public Note(string title, string text)
        {
            Title = title;
            Text = text;
        }
    }
}
