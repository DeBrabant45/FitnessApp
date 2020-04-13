using FitnessApp.Classes;
using FitnessApp.Models;
using FitnessApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FitnessApp.ViewModels
{
    public class ExercisesDetailViewModel : BaseViewModel
    {
        private readonly IExerciseStore _exerciseStore;
        private readonly IPageService _pageService;
        public Exercise Exercise { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public List<MuscleGroup> ListOfMuscleGroups { get; set; }

        public ExercisesDetailViewModel(ExerciseViewModel viewModel, IExerciseStore exerciseStore, IPageService pageService)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            _pageService = pageService;
            _exerciseStore = exerciseStore;
            SaveCommand = new Command(async () => await Save());
            Exercise = new Exercise
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
                Type = viewModel.Type,
                //ImageUrl = viewModel.ImageUrl, remember to add this for image later
            };

            ListOfMuscleGroups = PickerService.GetMuscleGroups().OrderBy(c => c.Value).ToList();
        }

        private MuscleGroup _selectedMuscleGroup;
        public MuscleGroup SelectedMuscleGroup
        {
            get
            {
                return _selectedMuscleGroup;
            }
            set
            {
                SetValue(ref _selectedMuscleGroup, value);
                Exercise.Type = _selectedMuscleGroup.Value;
            }
        }

        private async Task Save()
        {
            if (String.IsNullOrWhiteSpace(Exercise.Type))
            {
                await _pageService.DisplayAlert("Error", "Please enter a Muscle group.", "OK");
                return;
            }
            if (Exercise.Id == 0)
            {
                await _exerciseStore.AddExercise(Exercise);
                MessagingCenter.Send(this, Events.ExerciseAdded, Exercise);
            }
            else
            {
                await _exerciseStore.UpdateExercise(Exercise);
                MessagingCenter.Send(this, Events.ExerciseUpdated, Exercise);
            }
            await _pageService.PopAsync();
        }
    }
}
