using MauiTestApp.Data;
using MauiTestApp.Models;
using MauiTestApp.ViewModels;

namespace MauiTestApp;

public partial class MainPage : ContentPage
{
    TestDatabase testDatabase;

    public MainPage(TestDatabase testDb, NoteViewModel noteViewModel)
	{
		InitializeComponent();
        testDatabase = testDb;

        var notes = Task.Run(GetNotes);
        MainThread.BeginInvokeOnMainThread(() =>
        {
            noteViewModel.Notes.Clear();
            foreach (var note in notes.Result)
            {
                noteViewModel.Notes.Add(new NoteItem
                {
                    Id = note.Id,
                    Note = note.Note
                });
            }
        });

        BindingContext = noteViewModel;
    }

    private async Task<List<NoteItem>> GetNotes()
    {
        return await testDatabase.GetItemsAsync();
    }
}
