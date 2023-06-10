using MauiTestApp.Data;
using MauiTestApp.ViewModels;
using System.Collections.ObjectModel;

namespace MauiTestApp;

public partial class MainPage : ContentPage
{
    TestDatabase testDatabase;

    public MainPage(TestDatabase testDb)
	{
		InitializeComponent();
        testDatabase = testDb;

        BindingContext = new ObservableCollection<NoteViewModel>();
    }

    protected override void OnAppearing()
    {

    }
}
