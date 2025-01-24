using Microsoft.Maui.Controls;
using PetFeedingTracker.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PetFeedingTracker;

public partial class MainPage : ContentPage
{
    public ObservableCollection<Pet> Pets { get; set; } = new ObservableCollection<Pet>();

    public ICommand PetCommand { get; }
    public ICommand AddPetCommand { get; }

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;

        // Команда для перехода к деталям питомца
        PetCommand = new Command<Pet>(OnPetClicked);

        // Команда для перехода на AddPetPage
        AddPetCommand = new Command(OnAddPetClicked);
    }

    private async void OnPetClicked(Pet pet)
    {
        await Navigation.PushAsync(new PetDetailPage(pet));
    }

    private async void OnAddPetClicked()
    {
        Console.WriteLine("Кнопка нажата");
        // Переход на страницу AddPetPage
        var addPetPage = new AddPetPage();
        addPetPage.PetAdded += (sender, newPet) =>
        {
            Pets.Add(newPet); // Добавляем нового питомца в список
        };
        await Navigation.PushAsync(addPetPage);
    }
}
