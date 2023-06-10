using SQLite;

namespace MauiTestApp.Models
{
    public class NoteItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Note { get; set; }
    }
}
