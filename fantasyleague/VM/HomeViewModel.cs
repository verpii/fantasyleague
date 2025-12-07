using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using fantasyleague.DB;
using fantasyleague.M;
using fantasyleague.V;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasyleague.VM
{
    public partial class HomeViewModel : ObservableObject
    {
        private IDbService _dbService;


        [ObservableProperty]
        UserTeam userteam;

        public HomeViewModel(IDbService db)
        {
           _dbService = db;
            LoadAllMatches();
            LoadXd();
            
        }


        [RelayCommand]
        private async Task LoadXd()
        {
            Userteam = await _dbService.GetUserTeamAsync();
        }


        

        [RelayCommand]
        private async Task NavigateToMyTeam()
        {
            await Shell.Current.GoToAsync("myteam");
        }

        public ObservableCollection<Match> AllMatches { get; set; }

        [RelayCommand]
        private async Task NavigateToMarket()
        {
            await Shell.Current.GoToAsync("market");
        }



        [RelayCommand]
        public async Task TakePhotoAsync()
        {
            if (!MediaPicker.Default.IsCaptureSupported) return;

            var image = await MediaPicker.Default.CapturePhotoAsync();

            if (image != null)
            {
                string localUrl = Path.Combine(FileSystem.Current.AppDataDirectory, image.FileName);

                if (!File.Exists(localUrl))
                {
                    using Stream stream = await image.OpenReadAsync();
                    using FileStream fs = File.OpenWrite(localUrl);
                    await stream.CopyToAsync(fs);
                }

                Userteam.KepUrl = localUrl;
            }
        }



        [RelayCommand]
        private void LoadAllMatches()
            {
                    // Sample data - replace with your actual match data
                    AllMatches = new ObservableCollection<Match>
                {
                    new Match { Teams = "T1 vs Gen.G", League = "LCK Spring", MatchDate = DateTime.Now.AddHours(2), IsLive = false },
                    new Match { Teams = "DK vs HLE", League = "LCK Spring", MatchDate = DateTime.Now.AddHours(4), IsLive = false },
                    new Match { Teams = "KT vs KDF", League = "LCK Spring", MatchDate = DateTime.Now.AddHours(6), IsLive = false },
                    new Match { Teams = "BRO vs NS", League = "LCK Spring", MatchDate = DateTime.Now.AddHours(8), IsLive = false },
                    new Match { Teams = "G2 vs FNC", League = "LEC Winter", MatchDate = DateTime.Now.AddDays(1).AddHours(1), IsLive = false },
                    new Match { Teams = "MAD vs RGE", League = "LEC Winter", MatchDate = DateTime.Now.AddDays(1).AddHours(3), IsLive = false },
                    new Match { Teams = "TL vs C9", League = "LCS Spring", MatchDate = DateTime.Now.AddDays(1).AddHours(5), IsLive = false },
                    new Match { Teams = "100T vs FLY", League = "LCS Spring", MatchDate = DateTime.Now.AddDays(1).AddHours(7), IsLive = false },
                    new Match { Teams = "TES vs JDG", League = "LPL Spring", MatchDate = DateTime.Now.AddDays(2).AddHours(2), IsLive = false },
                    new Match { Teams = "BLG vs LNG", League = "LPL Spring", MatchDate = DateTime.Now.AddDays(2).AddHours(4), IsLive = false },
                    new Match { Teams = "T1 vs DK", League = "LCK Spring", MatchDate = DateTime.Now.AddDays(3).AddHours(3), IsLive = false },
                    new Match { Teams = "Gen.G vs KT", League = "LCK Spring", MatchDate = DateTime.Now.AddDays(3).AddHours(5), IsLive = false },
                };
           }


    }

    public class Match
    {
        public string Teams { get; set; }
        public string League { get; set; }
        public DateTime MatchDate { get; set; }
        public bool IsLive { get; set; }
    }
}
