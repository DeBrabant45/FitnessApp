using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitnessApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BackExercisesPage : ContentPage
    {
        public BackExercisesPage()
        {
            InitializeComponent();

            backList.ItemsSource = new List<Exercise>
            {
                new Exercise { Name = "Pull up", ImageUrl="http://lorempixel.com/100/100/people/1" },
                new Exercise { Name= "Row", ImageUrl="http://lorempixel.com/100/100/people/2"}
            };
        }
    }
}