using MauiTestApp.Data;
using MauiTestApp.ViewModels;
using System.Collections.ObjectModel;

namespace MauiTestApp;

public partial class MainPage : ContentPage
{
    TestDatabase testDatabase;
    public ObservableCollection<NoteViewModel> Notes { get; set; } = new();

    public MainPage(TestDatabase testDb)
	{
		InitializeComponent();
        testDatabase = testDb;
        BindingContext = this;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        var notes = await testDatabase.GetItemsAsync();
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Notes.Clear();
            foreach (var note in notes)
            {
                Notes.Add(new NoteViewModel
                {
                    Id = note.Id,
                    Note = note.Note
                });
            }
        });
    }
}
