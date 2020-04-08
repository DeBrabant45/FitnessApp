using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Services
{
    public interface IExerciseStore
    {
        Task<IEnumerable<Exercise>> GetExercisesAsync();
        Task<Exercise> GetExercise(int id);
        Task AddExercise(Exercise exercise);
        Task UpdateExercise(Exercise exercise);
        Task DeleteExercise(Exercise exercise);
    }
}
