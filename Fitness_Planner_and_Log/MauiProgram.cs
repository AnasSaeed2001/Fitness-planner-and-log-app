using Microsoft.Extensions.Logging;
using Fitness_Planner_and_Log.Repositories;
using Fitness_Planner_and_Log.MVVM.ViewModels;
using Fitness_Planner_and_Log.MVVM.Views;

namespace Fitness_Planner_and_Log;

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
        builder.Services.AddSingleton<WorkoutRepository>();
		builder.Services.AddTransient<AddDetailsPage>();
		builder.Services.AddTransient<AddDetails>();
#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
