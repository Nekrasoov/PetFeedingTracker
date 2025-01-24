using Microsoft.Maui.Controls;
using PetFeedingTracker.Models;
using System.Windows.Input;

namespace PetFeedingTracker
{
    public partial class PetDetailPage : ContentPage
    {
        public PetDetailPageViewModel ViewModel { get; } // ViewModel объединяет данные и команды

        public PetDetailPage(Pet pet)
        {
            InitializeComponent();

            // Проверяем, что переданный объект не null
            if (pet == null)
                throw new ArgumentNullException(nameof(pet), "Pet cannot be null");

            ViewModel = new PetDetailPageViewModel(pet);
            BindingContext = ViewModel; // Устанавливаем BindingContext на ViewModel
        }
    }

    public class PetDetailPageViewModel
    {
        public Pet Pet { get; } // Данные питомца
        public ICommand AddFeedingCommand { get; } // Команда для добавления кормления

        public PetDetailPageViewModel(Pet pet)
        {
            Pet = pet ?? throw new ArgumentNullException(nameof(pet), "Pet cannot be null"); // Защита от null
            AddFeedingCommand = new Command(OnAddFeedingClicked);
        }

        private async void OnAddFeedingClicked()
        {
            if (Pet == null)
            {
                // Логируем ошибку для отладки
                Console.WriteLine("Pet object is null. Cannot proceed with adding feeding.");
                return;
            }

            // Открытие страницы добавления кормления
            await Application.Current.MainPage.Navigation.PushAsync(new FeedingPage(Pet));
        }
    }
}
