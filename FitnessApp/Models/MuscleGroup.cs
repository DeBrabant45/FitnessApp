using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessApp.Models
{
    public class MuscleGroup
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
