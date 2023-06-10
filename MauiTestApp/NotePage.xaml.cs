using MauiTestApp.Data;

namespace MauiTestApp;

public partial class NotePage : ContentPage
{
    TestDatabase testDatabase;

	public NotePage(TestDatabase testDb)
	{
		InitializeComponent();
        testDatabase = testDb;
	}

    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        // Save the file.
    }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        // Delete the file.

        TextEditor.Text = string.Empty;
    }
}