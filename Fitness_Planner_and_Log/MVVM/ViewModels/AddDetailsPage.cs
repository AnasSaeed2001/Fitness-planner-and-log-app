using CommunityToolkit.Mvvm.ComponentModel;
using Fitness_Planner_and_Log.MVVM.Models;
using System.Windows.Input;

namespace Fitness_Planner_and_Log.MVVM.ViewModels;

[QueryProperty(nameof(CurrentWorkout), "CurrentWorkout")]
public partial class AddDetailsPage : ObservableObject
{
    WorkoutInformation currentWorkout;
    public ICommand SaveCommand { get; set; }
    public ICommand TakePhotoCommand { get; set; }

    public WorkoutInformation CurrentWorkout
    {
        get => currentWorkout;
        set
        {
            currentWorkout = value;
            OnPropertyChanged();
        }

    }

    private async void NavigateBack(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PopAsync();
    }

    public AddDetailsPage()
    {
        SaveCommand = new Command(async () =>
        {
            //call this
            Console.WriteLine(CurrentWorkout);
            App.WorkoutRepo.AddOrUpdate(CurrentWorkout);
            Console.WriteLine(App.WorkoutRepo.StatusMessage);


            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.Vibrate>();

            if (status == PermissionStatus.Granted)
            {
                HapticFeedback.Default.Perform(HapticFeedbackType.Click);
            }

        });


        TakePhotoCommand = new Command(async () => await TakePhoto());
    }



    public async Task TakePhoto()
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            var photo = await MediaPicker.Default.CapturePhotoAsync();

            if (photo != null)
            {
                // Save the file into local storage
                string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                using Stream sourceStream = await photo.OpenReadAsync();
                using FileStream localFileStream = File.OpenWrite(localFilePath);

                await sourceStream.CopyToAsync(localFileStream);

                // Save the image path to the current workout
                CurrentWorkout.Image = localFilePath;

                OnPropertyChanged("CurrentWorkout");
            }
        }
    }
}