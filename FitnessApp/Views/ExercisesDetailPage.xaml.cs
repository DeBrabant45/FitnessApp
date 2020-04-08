using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FitnessApp.Persistence;
using FitnessApp.Services;
using FitnessApp.ViewModels;

namespace FitnessApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExercisesDetailPage : ContentPage
    {
        public ExercisesDetailPage(ViewModels.ExerciseViewModel viewModel)
        {
            InitializeComponent();
            var exerciseStore = new SQLiteExerciseStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            Title = (viewModel.Name == null) ? "New Exercise" : "Edit Exercise";
            BindingContext = new ExercisesDetailViewModel(viewModel ?? new ExerciseViewModel(), exerciseStore, pageService);
        }
    }
}