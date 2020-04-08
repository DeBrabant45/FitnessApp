using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FitnessApp.Services;
using FitnessApp.Views;
using Xamarin.Forms;

namespace FitnessApp.ViewModels
{
    class ExercisesViewModel
    {
        public ICommand ChestExercisesNavCommand { get; set; }
        public ICommand BackExercisesNavCommand { get; set; }

        private IPageService _PageService;

        public ExercisesViewModel(IPageService pageService)
        {
            _PageService = pageService;
            ChestExercisesNavCommand = new Command(async () => await ChestPageNavigation());
            BackExercisesNavCommand = new Command(async () => await _PageService.PushAsync(new BackExercisesPage())); ;
        }

        public async Task ChestPageNavigation()
        {
            await _PageService.PushAsync(new ChestExercisesPage());
        }

    }
}
