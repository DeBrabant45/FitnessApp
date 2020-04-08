using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessApp.Models
{
    class MuscleGroup : List<Exercise>
    {
        public string Title { get; set; }
        public string ShortTitle { get; set; }

        public MuscleGroup(string title, string shortTitle)
        {
            Title = title;
            ShortTitle = shortTitle;
        }
    }
}
