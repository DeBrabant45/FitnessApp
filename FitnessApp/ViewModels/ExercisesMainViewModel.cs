using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FitnessApp.Models;
using FitnessApp.Services;
using FitnessApp.Views;
using Xamarin.Forms;

namespace FitnessApp.ViewModels
{
    class ExercisesMainViewModel
    {
        public ICommand ChestExercisesNavCommand { get; set; }
        public ICommand BackExercisesNavCommand { get; set; }
        public ICommand ArmsExercisesNavCommand { get; set; }
        public ICommand ShouldersExercisesNavCommand { get; set; }
        public ICommand LegsExercisesNavCommand { get; set; }
        public ICommand NeckExercisesNavCommand { get; set; }

        private IPageService _PageService;

        public ExercisesMainViewModel(IPageService pageService)
        {
            _PageService = pageService;
            ChestExercisesNavCommand = new Command(async () => await ChestListNavigation());
            BackExercisesNavCommand = new Command(async () => await BackListNavigation());
            ArmsExercisesNavCommand = new Command(async () => await ArmsListNavigation());
            ShouldersExercisesNavCommand = new Command(async () => await ShouldersListNavigation());
            LegsExercisesNavCommand = new Command(async () => await LegsListNavigation());
            NeckExercisesNavCommand = new Command(async () => await NeckListNavigation());
        }

        public async Task ChestListNavigation()
        {
            var exercisesListPage = new ExercisesListPage();
            exercisesListPage.Title = "Chest";
            await _PageService.PushAsync(exercisesListPage);
        }

        public async Task BackListNavigation()
        {
            var exercisesListPage = new ExercisesListPage();
            exercisesListPage.Title = "Back";
            await _PageService.PushAsync(exercisesListPage);
        }

        public async Task ArmsListNavigation()
        {
            var exercisesListPage = new ExercisesListPage();
            exercisesListPage.Title = "Arms";
            await _PageService.PushAsync(exercisesListPage);
        }

        public async Task ShouldersListNavigation()
        {
            var exercisesListPage = new ExercisesListPage();
            exercisesListPage.Title = "Shoulders";
            await _PageService.PushAsync(exercisesListPage);
        }

        public async Task LegsListNavigation()
        {
            var exercisesListPage = new ExercisesListPage();
            exercisesListPage.Title = "Legs";
            await _PageService.PushAsync(exercisesListPage);
        }

        public async Task NeckListNavigation()
        {
            var exercisesListPage = new ExercisesListPage();
            exercisesListPage.Title = "Neck";
            await _PageService.PushAsync(exercisesListPage);
        }
    }
}
