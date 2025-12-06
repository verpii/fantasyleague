using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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


            LoadPlayersAsync();
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
        private void  filteredByRole()
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



    }
}
    