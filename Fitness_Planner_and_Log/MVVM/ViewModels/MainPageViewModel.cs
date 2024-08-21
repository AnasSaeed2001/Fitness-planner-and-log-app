using Fitness_Planner_and_Log.MVVM.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace Fitness_Planner_and_Log.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainPageViewModel
    {
        public List<WorkoutInformation> WorkoutsInformation { get; set; }
        public WorkoutInformation CurrentWorkout { get; set; }
        //public WorkoutInformation CurrentWeight { get; set; }
        public ICommand AddOrUpdateCommand { get; set; }

        public DateTime SelectedDate { get; set; }
        public TimeSpan SelectedTime { get; set; }

        public MainPageViewModel()
        {

            SelectedDate = DateTime.Now;
            SelectedTime = DateTime.Now.TimeOfDay;

            GenerateNewWorkout();


            AddOrUpdateCommand = new Command(async () =>
            {
               
                App.WorkoutRepo.AddOrUpdate(CurrentWorkout);
                Console.WriteLine(App.WorkoutRepo.StatusMessage);

                GenerateNewWorkout();

                PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.Vibrate>();

                if(status == PermissionStatus.Granted)
                {
                    HapticFeedback.Default.Perform(HapticFeedbackType.Click);
                }

            });


        }

        private void GenerateNewWorkout()
        {
            var workoutNames = new[] {""};
            var image = new[] {""};
            var weights = new[] { 10, 20, 30, 40 };
            

            CurrentWorkout = new Faker<WorkoutInformation>()
                .RuleFor(x => x.WorkoutName, f => f.PickRandom(workoutNames))
                .RuleFor(x => x.Image, f => f.PickRandom(image))
                .RuleFor(x => x.Weight, f => f.PickRandom(weights))
                .RuleFor(x => x.Date, SelectedDate)
                .RuleFor(x => x.Time, SelectedTime)
                .Generate();
            Refresh();
        }

        private void Refresh()
        {
            WorkoutsInformation = App.WorkoutRepo.GetAll();
        }



        public void deleteWorkout()
        {
            App.WorkoutRepo.Delete(CurrentWorkout);
            Console.WriteLine(App.WorkoutRepo.StatusMessage);

            GenerateNewWorkout();
        }

    }
}
