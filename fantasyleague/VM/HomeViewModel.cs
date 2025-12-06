using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fantasyleague.V;

namespace fantasyleague.VM
{
    public partial class HomeViewModel : ObservableObject
    {
        [RelayCommand]
        private async Task NavigateToMyTeam()
        {
            await Shell.Current.GoToAsync("myteam");
        }


        [RelayCommand]
        private async Task NavigateToMarket()
        {
            await Shell.Current.GoToAsync("market");
        }


    }
}
