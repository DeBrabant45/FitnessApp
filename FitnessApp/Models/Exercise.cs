using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace FitnessApp.Models
{
    public class Exercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Type { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
