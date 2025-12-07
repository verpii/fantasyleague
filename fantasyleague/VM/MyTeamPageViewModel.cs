using __XamlGeneratedCode__;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using fantasyleague.DB;
using fantasyleague.M;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
//using static CoreFoundation.DispatchSource;

namespace fantasyleague.VM
{
    public partial class MyTeamPageViewModel : ObservableObject
    {

        private readonly IDbService _dbService;


        public MyTeamPageViewModel(IDbService db)
        {
            _dbService = db;
            PlayersInTeam = new ObservableCollection<Player>();

            LoadUserTeam();
        }
        
        public ObservableCollection<Player> PlayersInTeam { get; set; }

        [ObservableProperty]
        private UserTeam _userteam;


        [ObservableProperty]
        Player selectedPlayer;

        [ObservableProperty]
        private UserTeam refreshUserteam;

        async partial void OnUserteamChanged(UserTeam value)
        {
            RefreshUserteam = value;
        }

        public async Task LoadUserTeam()
        {
            Userteam = await _dbService.GetUserTeamAsync();
            PlayersInTeam.Clear();

            if (!string.IsNullOrEmpty(Userteam.RosterString))
            {

                Userteam.RosterString.Split(',').ToList().ForEach(i =>
                {
                    Task<Player> n = _dbService.GetPlayerByIgnAsync(i);
                    PlayersInTeam.Add(n.Result);
                });
            }
        }
        //[RelayCommand]
        //public void RefreshData()
        //{
        //    OnPropertyChanged(_userteam.TeamName);
        //    OnPropertyChanged(nameof(_userteam.CurrentPoints));
        //    OnPropertyChanged(nameof(_userteam.Budget));
        //}


        [RelayCommand]
        public async Task NavigateToMarketAsync()
        {
            await Shell.Current.GoToAsync("market");
        }


        [RelayCommand]
        public async Task ShareAsync()
        {

            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
            {
                string content = "";

                foreach (var item in PlayersInTeam)
                {
                    content += $"{item.Ign} ({item.Role}); ";

                }
                

                await Share.Default.RequestAsync(new ShareTextRequest()
                {
                    Title = "They will Smash this Season",
                    Text = content
                });
            }
        }


     




        [RelayCommand]
        public async Task DeletePlayer()
        {
            if(SelectedPlayer != null)
            {
                Userteam.Budget += SelectedPlayer.Sellingprice;

                PlayersInTeam.Remove(SelectedPlayer);

                string newteam = "";
                int count = 0;

                foreach (var player in PlayersInTeam)
                {
                   
                    if (count == 0)
                    {
                        newteam = newteam + player.Ign;
                        count++;
                    }
                    else
                    {
                        newteam = newteam + $",{player.Ign}";
                    }

                        
                }

                Userteam.RosterString = newteam;

                _dbService.UpdateUserTeamAsync(Userteam);



            }


        }


    }
}