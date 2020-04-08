using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FitnessApp.Classes;
using FitnessApp.Models;
using FitnessApp.Services;
using FitnessApp.Views;
using Xamarin.Forms;

namespace FitnessApp.ViewModels
{
    public class ChestExercisesViewModel : BaseViewModel
    {
        private ExerciseViewModel _selectedExercise;
        private IExerciseStore _exerciseStore;
        private IPageService _pageService;

        private bool _isDataLoaded;

        public ObservableCollection<ExerciseViewModel> Exercises { get; private set; } = new ObservableCollection<ExerciseViewModel>();

        public ExerciseViewModel SelectedExercise
        {
            get { return _selectedExercise; }
            set { SetValue(ref _selectedExercise, value); }
        }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddExerciseCommand { get; private set; }
        public ICommand SelectExerciseCommand { get; private set; }
        public ICommand DeleteExerciseCommand { get; private set; }

        public ChestExercisesViewModel(IExerciseStore exerciseStore, IPageService pageService)
        {
            _exerciseStore = exerciseStore;
            _pageService = pageService;

            LoadDataCommand = new Command(async () => await LoadData());
            AddExerciseCommand = new Command(async () => await AddExercise());
            SelectExerciseCommand = new Command<ExerciseViewModel>(async e => await SelectExercise(e));
            DeleteExerciseCommand = new Command<ExerciseViewModel>(async e => await DeleteExercise(e));

            MessagingCenter.Subscribe<ExercisesDetailViewModel, Exercise>(this, Events.ExerciseAdded, OnExerciseAdded);
            MessagingCenter.Subscribe<ExercisesDetailViewModel, Exercise>(this, Events.ExerciseUpdated, OnExerciseUpdated);
        }

        private void OnExerciseAdded(ExercisesDetailViewModel source, Exercise exercise)
        {
            Exercises.Add(new ExerciseViewModel(exercise));
        }

        private void OnExerciseUpdated(ExercisesDetailViewModel source, Exercise exercise)
        {
            var exerciseInList = Exercises.Single(e => e.Id == exercise.Id);

            exerciseInList.Id = exercise.Id;
            exerciseInList.Name = exercise.Name;
            exerciseInList.Type = exercise.Type;
            exerciseInList.Description = exercise.Description;
            //add image here when ready
        }

        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;
            var exercises = await _exerciseStore.GetExercisesAsync();
            foreach (var exercise in exercises)
            {
                if (exercise.Type == "Chest")
                    Exercises.Add(new ExerciseViewModel(exercise));
            }

        }

        private async Task AddExercise()
        {
            await _pageService.PushAsync(new ExercisesDetailPage(new ExerciseViewModel()));
        }

        private async Task SelectExercise(ExerciseViewModel exercise)
        {
            if (exercise == null)
                return;

            SelectedExercise = null;
            await _pageService.PushAsync(new ExercisesDetailPage(exercise));
        }

        private async Task DeleteExercise(ExerciseViewModel exerciseViewModel)
        {
            if (await _pageService.DisplayAlert("Warning", $"Are you sure you want to delete {exerciseViewModel.Name}?", "Yes", "No"))
            {
                Exercises.Remove(exerciseViewModel);

                var exercise = await _exerciseStore.GetExercise(exerciseViewModel.Id);
                await _exerciseStore.DeleteExercise(exercise);
            }
        }

    }
}
