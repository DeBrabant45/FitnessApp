using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FitnessApp.ViewModels;
using FitnessApp.Models;
using FitnessApp.Services;

namespace FitnessApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExercisesMainPage : ContentPage
    {
        public ExercisesMainPage()
        {
            InitializeComponent();
            var pageService = new PageService();
            BindingContext = new ExercisesMainViewModel(pageService);
        }
    }
}