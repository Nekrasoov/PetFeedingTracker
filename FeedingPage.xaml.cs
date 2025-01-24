using Microsoft.Maui.Controls;
using PetFeedingTracker.Models;
using System;
using System.Windows.Input;

namespace PetFeedingTracker;

public partial class FeedingPage : ContentPage
{
    private readonly Pet _pet;

    public FeedingPage(Pet pet)
    {
        InitializeComponent();

        _pet = pet ?? throw new ArgumentNullException(nameof(pet), "Pet cannot be null");
        BindingContext = this;

        QuickFeedingCommand = new Command(OnQuickFeedingClicked);
        ManualFeedingCommand = new Command(OnManualFeedingClicked);
    }

    public ICommand QuickFeedingCommand { get; }
    public ICommand ManualFeedingCommand { get; }

    private async void OnQuickFeedingClicked()
    {
        var feedingRecord = new FeedingRecord
        {
            Time = DateTime.Now,
            Notes = "Быстрое кормление"
        };

        _pet.FeedingRecords.Add(feedingRecord);

        await DisplayAlert("Успех", "Кормление добавлено!", "OK");
        await Navigation.PopAsync();
    }

    private async void OnManualFeedingClicked()
    {
        DateTime? selectedDateTime = await ShowDateTimePickerAsync();

        if (selectedDateTime != null)
        {
            var feedingRecord = new FeedingRecord
            {
                Time = selectedDateTime.Value,
                Notes = "Ручное кормление"
            };

            _pet.FeedingRecords.Add(feedingRecord);

            await DisplayAlert("Успех", $"Кормление добавлено на {selectedDateTime.Value:G}", "OK");
            await Navigation.PopAsync();
        }
    }

    private async Task<DateTime?> ShowDateTimePickerAsync()
    {
        DateTime selectedDate = DateTime.Now.Date;
        TimeSpan selectedTime = DateTime.Now.TimeOfDay;

        
        bool dateConfirmed = await Application.Current.MainPage.DisplayPromptAsync(
            "Выберите дату",
            "Введите дату в формате ГГГГ-ММ-ДД",
            initialValue: selectedDate.ToString("yyyy-MM-dd")) is string dateInput &&
            DateTime.TryParse(dateInput, out selectedDate);

        if (!dateConfirmed)
            return null;

        bool timeConfirmed = await Application.Current.MainPage.DisplayPromptAsync(
            "Выберите время",
            "Введите время в формате ЧЧ:ММ",
            initialValue: selectedTime.ToString(@"hh\:mm")) is string timeInput &&
            TimeSpan.TryParse(timeInput, out selectedTime);

        if (!timeConfirmed)
            return null;

        return selectedDate + selectedTime;
    }
}
