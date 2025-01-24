

namespace PetFeedingTracker.Models
{
    public class FeedingRecord
    {
        public int Id { get; set; }  
        public int PetId { get; set; } 
        public DateTime Time { get; set; } 
        public string Notes { get; set; } = string.Empty;   
    }

}
