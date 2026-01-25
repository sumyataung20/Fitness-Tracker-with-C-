

namespace FitnessTracker.Models
{
    public class ActivityDescription
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public string Description { get; set; } = string.Empty; // Default value
        public double MET { get; set; }
    }
}
