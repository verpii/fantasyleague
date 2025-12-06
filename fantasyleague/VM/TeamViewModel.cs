using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using fantasyleague.M;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fantasyleague.DB;

namespace fantasyleague.VM
{
    public partial class TeamViewModel : ObservableObject
    {

        private readonly IDbService _db;
    

        [ObservableProperty]
        private UserTeam userTeam;

        public TeamViewModel(IDbService db)
        {
            _db = db;
          //  LoadUserTeam();
        }

        //private async Task LoadUserTeam()
        //{
        //    userTeam = await _db.GetUserTeamAsync();
        //}


        
        //public bool CanAddPlayer(Player newPlayer)
        //{
        //    if (UserTeam?.Roster == null)
        //    {
        //        return false;
        //    }
        //    var sameTeam = userTeam.Roster.Count(p => p.Team == newPlayer.Team);
            
        //    if (sameTeam >= 2)
        //    {
        //        WeakReferenceMessenger.Default.Send("Max 2 player from same team.");
        //        return false;
        //    }

        //    if (newPlayer.Buyingprice > UserTeam.Budget)
        //    {
        //        WeakReferenceMessenger.Default.Send("Not enough budget.");
        //        return false;
        //    }

        //    var roleexist = userTeam.Roster.Any(p => p.Role == newPlayer.Role);
        //    if (roleexist)
        //    {
        //        WeakReferenceMessenger.Default.Send($"You already have a {newPlayer.Role} in your team.");
        //        return false;
        //    }


        //    return true;

        //}

        //[RelayCommand]
        //private async Task AddPlayer(Player newPlayer)
        //{
        //    if (CanAddPlayer(newPlayer))
        //    {
        //        var newRoster = UserTeam.Roster.ToList();
        //        newRoster.Add(newPlayer);

        //        UserTeam.Roster = newRoster;
        //        UserTeam.Budget -= newPlayer.Buyingprice;

        //        await _db.SaveUserTeamAsync(UserTeam);

                
        //        OnPropertyChanged(nameof(UserTeam));

        //        WeakReferenceMessenger.Default.Send($"{newPlayer.Ign} sikeresen leigazolva!");

        //    }
        //}



        //[RelayCommand]
        //private async Task RemovePlayer(Player player)
        //{
        //    if (UserTeam?.Roster == null) return;

        //    var newRoster = UserTeam.Roster.ToList();

        //    if (newRoster.Remove(player))
        //    {
        //        UserTeam.Roster = newRoster; 
        //        UserTeam.Budget += player.Sellingprice;

        //        await _db.SaveUserTeamAsync(UserTeam);
        //        OnPropertyChanged(nameof(UserTeam));

        //        WeakReferenceMessenger.Default.Send($"{player.Ign} sikeresen eladva!");
        //    }
        //    else
        //    {
        //        WeakReferenceMessenger.Default.Send("Hiba történt a játékos eltávolítása során.");
        //    }

        //}





    }
}
