using MauiTestApp.Data;
using MauiTestApp.Models;
using Microsoft.Extensions.Logging;
using MauiTestApp.Services;
using MauiTestApp.ViewModels;

namespace MauiTestApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddTransient<MainPage>();

		builder.Services.AddSingleton<NoteItem>();
		builder.Services.AddSingleton<NoteViewModel>();
		builder.Services.AddTransient<NotePage>();

        builder.Services.AddSingleton<MonkeyService>();
        builder.Services.AddSingleton<MonkeysViewModel>();
		builder.Services.AddTransient<Monkeys>();

        builder.Services.AddSingleton<TestDatabase>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
