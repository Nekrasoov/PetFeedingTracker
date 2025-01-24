using Microsoft.Maui.Controls;
using PetFeedingTracker.Models;

namespace PetFeedingTracker
{
    public partial class AddPetPage : ContentPage
    {
        public event EventHandler<Pet>? PetAdded;

        public AddPetPage()
        {
            InitializeComponent();
            BindingContext = this;

            SavePetCommand = new Command(OnSavePetClicked);
        }

        public Command SavePetCommand { get; }

        private async void OnSavePetClicked()
        {
            var petName = PetNameEntry.Text;
            var petType = PetTypePicker.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(petName) || string.IsNullOrEmpty(petType))
            {
                await DisplayAlert("Ошибка", "Введите имя и выберите тип питомца.", "OK");
                return;
            }

            var newPet = new Pet
            {
                Name = petName,
                Type = petType
            };

           
            PetAdded?.Invoke(this, newPet);

            
            await Navigation.PopAsync();
        }
    }
}
