using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using PetFeedingTracker.Models;

namespace PetFeedingTracker.ViewModels
{
    public class PetsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Pet> Pets { get; set; } = new ObservableCollection<Pet>();

        public ICommand AddPetCommand { get; }
        public ICommand DeletePetCommand { get; }

        public PetsViewModel()
        {
            AddPetCommand = new Command(AddPet);
            DeletePetCommand = new Command<Pet>(DeletePet);
        }
        
        private void AddPet()
        {
            var newPet = new Pet { Name = "Новое животное", Type = "Кошка" };
            Pets.Add(newPet);
            OnPropertyChanged(nameof(Pets));
        }

        private void DeletePet(Pet pet)
        {
            if (pet != null)
                Pets.Remove(pet);
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}