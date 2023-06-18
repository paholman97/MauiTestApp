using MauiTestApp.Models;
using System.Collections.ObjectModel;

namespace MauiTestApp.ViewModels
{
    public class NoteViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public ObservableCollection<NoteItem> Notes { get; } = new();
    }
}
