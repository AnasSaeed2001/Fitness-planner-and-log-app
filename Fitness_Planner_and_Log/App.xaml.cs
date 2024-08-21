using Fitness_Planner_and_Log.Repositories;
using Fitness_Planner_and_Log.MVVM.Views;

namespace Fitness_Planner_and_Log;

public partial class App : Application
{
    public static WorkoutRepository WorkoutRepo { get; private set; }
    public App(WorkoutRepository repo)
	{
		InitializeComponent();
		WorkoutRepo = repo;

		MainPage = new AppShell();
	}
}
