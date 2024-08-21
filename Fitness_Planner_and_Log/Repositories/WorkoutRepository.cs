using SQLite;
using Fitness_Planner_and_Log.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness_Planner_and_Log.Repositories
{
    public class WorkoutRepository
    {
        SQLiteConnection connection;
        public string StatusMessage { get; set; }

        public WorkoutRepository()
        {
            connection = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
            connection.CreateTable<WorkoutInformation>();
        }

        public void AddOrUpdate(WorkoutInformation workoutInformation)
        {
            int result = 0;
            try
            {
                if(workoutInformation.Id !=0)
                {
                    result = connection.Update(workoutInformation);
                    StatusMessage = $"{result} row(s) updated";
                }
                else
                {
                    result = connection.Insert(workoutInformation);
                    StatusMessage = $"{result} row(s) added";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }

        }

        public List<WorkoutInformation> GetAll()
        {
            try
            {
                return connection.Table<WorkoutInformation>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $" Error : {ex.Message}";
            }
            return null;
        }

        public List<WorkoutInformation> GetAll2()
        {
            try
            {
                return connection.Query<WorkoutInformation>("SELECT * FROM Workouts").ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $" Error : {ex.Message}";
            }
            return null;
        }

        public WorkoutInformation Get(int id)
        {
            try
            {
                return connection.Table<WorkoutInformation>()
                .FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                StatusMessage = $" Error : {ex.Message}";
            }
            return null;
        }

        public void Delete(WorkoutInformation workoutInformation)
        {
            try
            {

                connection.Delete(workoutInformation);
            }
            catch(Exception ex)
            {
                StatusMessage = $" Error : {ex.Message}";
            }
        }

    }
}
