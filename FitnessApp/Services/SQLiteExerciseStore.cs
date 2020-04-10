using FitnessApp.Models;
using FitnessApp.Persistence;
using FitnessApp.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp
{
    public class SQLiteExerciseStore : IExerciseStore
    {
        private SQLiteAsyncConnection _connection;
        public SQLiteExerciseStore(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Exercise>();
        }
        public async Task AddExercise(Exercise exercise)
        {
            await _connection.InsertAsync(exercise);
        }

        public async Task DeleteExercise(Exercise exercise)
        {
            await _connection.DeleteAsync(exercise);
        }

        public async Task<Exercise> GetExercise(int id)
        {
            return await _connection.FindAsync<Exercise>(id);
        }

        public async Task<IEnumerable<Exercise>> GetExercisesAsync()
        {
            return await _connection.Table<Exercise>().ToListAsync();
        }

        public async Task UpdateExercise(Exercise exercise)
        {
            await _connection.UpdateAsync(exercise);
        }
    }
}
