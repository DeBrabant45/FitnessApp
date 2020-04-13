using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessApp.Services
{
    class PickerService
    {
        public static List<MuscleGroup> GetMuscleGroups()
        {
            var muscleGroupes = new List<MuscleGroup>
            {
                new MuscleGroup() {Key=1, Value="Arms"},
                new MuscleGroup() {Key=2, Value="Back"},
                new MuscleGroup() {Key=3, Value="Chest"},
                new MuscleGroup() {Key=4, Value="Legs"},
                new MuscleGroup() {Key=5, Value="Neck"},
                new MuscleGroup() {Key=6, Value="Shoulders"}
            };

            return muscleGroupes;
        }
    }
}
