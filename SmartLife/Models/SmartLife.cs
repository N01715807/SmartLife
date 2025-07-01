using System.ComponentModel.DataAnnotations;

namespace SmartLife.Models
{
    public class SmartLifeClass
    {
        public required int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public required string Name { get; set; }

        [Range(0, 100, ErrorMessage = "Age must be between 0 and 100")]
        public required int Age { get; set; }

        [Required(ErrorMessage = "Occupation is required")]
        public required string Occupation { get; set; }

        [Required(ErrorMessage = "Monthly_salary is required")]
        public required decimal Monthly_salary { get; set; }

        public required MoodType Mood { get; set; }

        public required PersonalityType Personality { get; set; }

        [Range(0, 30, ErrorMessage = "Familybond is required")]
        public required int Familybond { get; set; }

        public DateTime LastUpdated { get; set; }

    }
}


