using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessApp.ViewModels
{

    public class ExerciseViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public ExerciseViewModel() { }

        public ExerciseViewModel(Exercise exercise)
        {
            Id = exercise.Id;
            _type = exercise.Type;
            _name = exercise.Name;
            _description = exercise.Description;
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetValue(ref _name, value);
            }
        }

        private string _type;
        public string Type
        {
            get { return _type; }
            set { SetValue(ref _type, value); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetValue(ref _description, value); }
        }
    }
}
