using FitnessTracker.Models; // This is needed for Activity and ActivityDescription

namespace FitnessTracker.Models
{
    public class Activity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; // Default value
}
    
}
