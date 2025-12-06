using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using fantasyleague.M;
using System.Collections.Generic;
using System.Linq;

namespace fantasyleague.VM
{
    public partial class MyTeamViewModel : ObservableObject
    {
        private readonly TeamViewModel _teamViewModel;

        public MyTeamViewModel(TeamViewModel teamViewModel)
        {

            _teamViewModel = teamViewModel;
        }

       
        public UserTeam CurrentUserTeam => _teamViewModel.UserTeam;

        public List<Player> RosterPlayers => new List<Player>();

        public string TeamName => CurrentUserTeam?.TeamName ?? "Saját Csapat";

        public int TotalWeeklyScore => RosterPlayers.Sum(p => p.CurrentPoints);

        [RelayCommand]
        public void RefreshData()
        {
            OnPropertyChanged(nameof(TeamName));
            OnPropertyChanged(nameof(RosterPlayers));
            OnPropertyChanged(nameof(TotalWeeklyScore));
            OnPropertyChanged(nameof(CurrentUserTeam));
        }
    }
}