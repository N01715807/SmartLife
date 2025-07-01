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

        public required string Mood { get; set; }

        public required string Personality { get; set; }

        [Range(0, 30, ErrorMessage = "Familybond is required")]
        public required int Familybond { get; set; }

        public DateTime LastUpdated { get; set; }

        public int CalculateScore()
        {
            int score = 0;
            int agescore = 30 - Math.Abs(Age - 30);
            if (agescore < 0)
                agescore = 0;
            score += agescore;

            score = score + (int)Math.Min(Monthly_salary / 1000, 30);

            var moodscore = new Dictionary<string,int>
            {
                {"happy",10},
                {"excited",8},
                {"calm",5},
                {"nature",0},
                {"anxious",-5},
                {"sad",-8},
                {"angry",-10}
            };
            if (moodscore.ContainsKey(Mood.ToLower())) 
            {
                score = score + moodscore[Mood.ToLower()];
            }

            score = score + Familybond;

            return score;
        }
    }
}


