using MauiTestApp.Data;
using MauiTestApp.Models;

namespace MauiTestApp;

public partial class NotePage : ContentPage
{
    TestDatabase database;
    NoteItem noteItem { get; set; } = new();

    public NotePage(TestDatabase testDatabase)
    {
        InitializeComponent();
        database = testDatabase;
        BindingContext = noteItem;
    }

    async void SaveButton_Clicked(object sender, EventArgs e)
    {
        // Save the file.
        if (string.IsNullOrWhiteSpace(noteItem.Note))
        {
            await DisplayAlert("Note empty.", "Please enter text in the Note field.", "Okay");
            return;
        }

        await database.SaveItemAsync(noteItem);
        await Shell.Current.GoToAsync("MainPage");
    }
}