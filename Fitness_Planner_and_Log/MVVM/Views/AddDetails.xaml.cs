using Fitness_Planner_and_Log.MVVM.ViewModels;

namespace Fitness_Planner_and_Log.MVVM.Views;

public partial class AddDetails : ContentPage
{
	public AddDetails(AddDetailsPage viewModel)
	{
        InitializeComponent();
		BindingContext = viewModel;

	}
}