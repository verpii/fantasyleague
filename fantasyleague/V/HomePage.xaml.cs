using CommunityToolkit.Mvvm.Input;

namespace fantasyleague.V
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
           
        }


        [RelayCommand]
        private async Task NavigateToMyTeam()
        {
            await Shell.Current.GoToAsync("//team");
        }


        [RelayCommand]
        private async Task NavigateToMarket()
        {
            await Shell.Current.GoToAsync("//market");
        }

        [RelayCommand]
        private async Task NavigateToEsportHub()
        {
            await Shell.Current.GoToAsync("//esporthub");
        }

    }
}