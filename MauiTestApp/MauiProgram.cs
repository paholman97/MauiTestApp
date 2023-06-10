using MauiTestApp.Data;
using MauiTestApp.Models;
using Microsoft.Extensions.Logging;

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

		builder.Services.AddSingleton<NoteItem>();
		builder .Services.AddTransient<NotePage>();

		builder.Services.AddSingleton<TestDatabase>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
