using Fitness_Planner_and_Log.MVVM.Views;

namespace Fitness_Planner_and_Log;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(AddDetails), typeof(AddDetails));
	}
}