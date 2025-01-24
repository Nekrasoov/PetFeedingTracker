using PetFeedingTracker.ViewModels;

namespace PetFeedingTracker
{
    public partial class App : Application
    {
        public PetsViewModel PetsViewModel { get; } = new PetsViewModel();

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());

        }
    }
}