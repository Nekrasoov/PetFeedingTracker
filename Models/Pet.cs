using System.Collections.ObjectModel;

namespace PetFeedingTracker.Models
{
   
    public class Pet
    {
        public string Name { get; set; } = string.Empty; // Имя
        public string Type { get; set; } = string.Empty; // Тип животного
        public ObservableCollection<FeedingRecord> FeedingRecords { get; set; } = new ObservableCollection<FeedingRecord>();
    }

   

}
