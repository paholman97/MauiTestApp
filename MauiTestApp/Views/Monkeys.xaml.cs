using MauiTestApp.ViewModels;

namespace MauiTestApp;

public partial class Monkeys : ContentPage
{
	public Monkeys(MonkeysViewModel monkeysViewModel)
	{
		InitializeComponent();
		BindingContext = monkeysViewModel;
	}
}