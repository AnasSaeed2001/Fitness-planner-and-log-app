using Fitness_Planner_and_Log.MVVM.Models;
using Fitness_Planner_and_Log.MVVM.ViewModels;

namespace Fitness_Planner_and_Log.MVVM.Views;

public partial class MainPage : ContentPage
{
	MainPageViewModel viewPage = new MainPageViewModel();
	public MainPage()
	{
		InitializeComponent();
		BindingContext = viewPage;
	}

	public void deleteWorkout(object sender, EventArgs e)
	{
		viewPage.deleteWorkout();
	}

	public async void goToAddDetalsPage(object sender, EventArgs e)
	{
		WorkoutInformation currentWorkout = viewPage.CurrentWorkout;

		Console.WriteLine(currentWorkout.Id);
		Console.WriteLine("Practice " + currentWorkout.Id.ToString());

		await Shell.Current.GoToAsync($"AddDetails", new Dictionary<string, object> 
		{
			{"CurrentWorkout", currentWorkout }
		});


	}

	//private async void Workout_Information_Button_Clicked(object sender, EventArgs e)
	//{
	//await Shell.Current.GoToAsync(nameof(WorkoutInformation), true);
	//}

	private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		var selectedItem = e.CurrentSelection.FirstOrDefault() as WorkoutInformation;
		Console.WriteLine(selectedItem);
		if (selectedItem != null)
		{
        // Navigate to AddDetailsPage passing the selected workout information
			await Shell.Current.GoToAsync($"AddDetails", new Dictionary<string, object> 
			{
				{"CurrentWorkout", selectedItem }
			});
		}
	}

}