using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessApp.Models;
using FitnessApp.Persistence;
using FitnessApp.Services;
using FitnessApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitnessApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChestExercisesPage : ContentPage
    {
        public ChestExercisesPage()
        {
            var exerciseStore = new SQLiteExerciseStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModel = new ChestExercisesViewModel(exerciseStore, pageService);
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);
            base.OnAppearing();
        }
        void OnExerciseSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectExerciseCommand.Execute(e.SelectedItem);
        }
        public ChestExercisesViewModel ViewModel
        {
            get { return BindingContext as ChestExercisesViewModel; }
            set { BindingContext = value; }

        }
    }
}