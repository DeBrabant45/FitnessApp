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
    public partial class ExercisesListPage : ContentPage //if I go back to using conetentpage change here
    {
        public ExercisesListPage()
        {
            var exerciseStore = new SQLiteExerciseStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModel = new ExercisesListViewModel(exerciseStore, pageService);
            InitializeComponent();
        }

        protected override void OnAppearing() //If I go back to using contentPage use OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);
            base.OnAppearing();
        }
        void OnExerciseSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectExerciseCommand.Execute(e.SelectedItem);
        }
        public ExercisesListViewModel ViewModel
        {
            get { return BindingContext as ExercisesListViewModel; }
            set { BindingContext = value; }

        }
    }
}