using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness_Planner_and_Log.MVVM.Models
{
    [SQLite.Table("Workouts")]
    public class WorkoutInformation
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [SQLite.Column("workoutName"), Indexed, NotNull]
        public string WorkoutName { get; set; }
        
        public string Image { get; set; }

        public double Weight { get; set; }

        public DateTime Date { get; set; }
        
        public TimeSpan Time { get; set; }

        public string Description { get; set; }
    }


}
