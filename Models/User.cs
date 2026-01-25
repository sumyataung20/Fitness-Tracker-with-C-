namespace FitnessTracker.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public int CalorieGoal { get; set; } = 0;

        public decimal WeightKg { get; set; }
        public int TimeTakenDays { get; set; } // number of days to burn calorie goal

    }
}
