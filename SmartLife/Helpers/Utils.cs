using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartLife.Models;
namespace SmartLife.Helpers
{
    public static class Utils
    {
        public static int CalculateScore(SmartLifeClass s)
        {
            int score = 0;
            int agescore = 30 - Math.Abs(s.Age - 30);
            if (agescore < 0)
                agescore = 0;
            score += agescore;

            score = score + (int)Math.Min(s.Monthly_salary / 1000, 30);

            var moodscore = new Dictionary<MoodType, int>
            {
                {MoodType.happy,10},
                {MoodType.excited,8},
                {MoodType.calm,5},
                {MoodType.nature,0},
                {MoodType.anxious,-5},
                {MoodType.sad,-8},
                {MoodType.angry,-10}
            };
            if (moodscore.ContainsKey(s.Mood))
            {
                score = score + moodscore[s.Mood];
            }

            score = score + s.Familybond;

            return score;
        }
    }
}
