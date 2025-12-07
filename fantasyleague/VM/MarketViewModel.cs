using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using fantasyleague.DB;
using fantasyleague.M;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasyleague.VM
{
    public partial class MarketViewModel : ObservableObject
    {
        private readonly IDbService _dbService;

        public ObservableCollection<Player> AllPlayers { get; set; }

        public ObservableCollection<Player> FilteredPlayers { get; set; }

        public ObservableCollection<Player> UserTeamPlayers { get; set; }


        private UserTeam _userTeam;


        [ObservableProperty]
        string searchText = string.Empty;

        [ObservableProperty]
        private PlayerRole? selectedRole;

        [ObservableProperty]
        Player selectedPlayer;

        [ObservableProperty]
        private bool isLoading;

        public List<PlayerRole> Roles { get; } = Enum.GetValues<PlayerRole>().ToList();


       
        public MarketViewModel(IDbService dbService) 
        {
            this._dbService = dbService;

            AllPlayers = new ObservableCollection<Player>();
            FilteredPlayers = new ObservableCollection<Player>();
            UserTeamPlayers = new ObservableCollection<Player>();
            
            LoadUserTeam();
            LoadPlayersAsync();
        }



        [RelayCommand]
        private async Task LoadUserTeam()
        {
            var data = await _dbService.GetUserTeamAsync();
            _userTeam = data;
            UserTeamPlayers.Clear();

            if (!string.IsNullOrEmpty(_userTeam.RosterString))
            {

                data.RosterString.Split(',').ToList().ForEach(i =>
               {
                   var player = AllPlayers.FirstOrDefault(p => p.Ign == i);
                   if (player != null)
                   {
                       UserTeamPlayers.Add(player);
                   }
               });
            }

        }





        [RelayCommand]
        private async Task LoadPlayersAsync()
        {
            IsLoading = true;

            try
            {
                var players = await _dbService.GetAllPlayersAsync();
                AllPlayers.Clear();
                foreach (var player in players)
                {
                    AllPlayers.Add(player);
                }
                ApplyFilters();
            }
            finally
            {
                IsLoading = false;
            }

        }



        [RelayCommand]
        private void filteredByRole()
        {
           ApplyFilters();
        }


        [RelayCommand]
        private void ClearFilters()
        {
            SelectedRole = null;
            SearchText = string.Empty;
            ApplyFilters();
        }



        async partial void OnSearchTextChanged(string value)
        {
            ApplyFilters();
        }

        async partial void OnSelectedRoleChanged(PlayerRole? value)
        {
            ApplyFilters();
        }


        private void ApplyFilters()
        {
            var filtered = AllPlayers.AsEnumerable();

            if (selectedRole.HasValue)
            {
                filtered = filtered.Where(p => p.Role == selectedRole.Value);
            }

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                filtered = filtered.Where(p => p.Ign.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                                               p.IrlName.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                                               p.Team.Contains(searchText, StringComparison.OrdinalIgnoreCase));
            }

            FilteredPlayers.Clear();

            foreach (var player in filtered)
            {
                FilteredPlayers.Add(player);
            }



        }



        [RelayCommand]
        private async Task BuyButton(Player newPlayer)
        {
            if (CanAddPlayer(newPlayer))
            {

                string ign = newPlayer.Ign;

                _userTeam.RosterString = string.IsNullOrEmpty(_userTeam.RosterString) ? ign : $"{_userTeam.RosterString},{ign}";


                _userTeam.Budget -= newPlayer.Buyingprice;

                await _dbService.SaveUserTeamAsync(_userTeam);

                await LoadUserTeam();


                OnPropertyChanged(nameof(UserTeam));

                WeakReferenceMessenger.Default.Send($"Great Sign! {newPlayer.Ign} is ready to rumble!");
            }
            return;

            
        }


        public bool CanAddPlayer(Player newPlayer)
        {
            if (UserTeamPlayers == null)
            {
                return false;
            }
            var sameTeam = UserTeamPlayers.Count(p => p.Team == newPlayer.Team);

            if (sameTeam >= 2)
            {
                WeakReferenceMessenger.Default.Send("Max 2 player from same team.");
                return false;
            }

            if (newPlayer.Buyingprice > _userTeam.Budget)
            {
                WeakReferenceMessenger.Default.Send("Not enough budget.");
                return false;
            }

            var roleexist = UserTeamPlayers.Any(p => p.Role == newPlayer.Role);
            if (roleexist)
            {
                WeakReferenceMessenger.Default.Send($"You already have a {newPlayer.Role} in your team.");
                return false;
            }


            return true;

        }


        
    





    }
}
    