using CommunityToolkit.Mvvm.Input;
using fantasyleague.VM;

namespace fantasyleague.V
{
    public partial class HomePage : ContentPage
    {

        HomeViewModel viewModel;


        public HomePage(HomeViewModel vm)
        {
            viewModel = vm;
            InitializeComponent();
            BindingContext = viewModel; 
           
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