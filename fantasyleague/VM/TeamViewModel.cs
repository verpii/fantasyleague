using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using fantasyleague.M;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasyleague.VM
{
    public partial class TeamViewModel : ObservableObject
    {
        [ObservableProperty]
        private UserTeam userTeam = new UserTeam();


        public TeamViewModel()
        {
        }

        public bool CanAddPlayer(Player newPlayer)
        {
            var sameTeam = userTeam.Roster.Count(p => p.Team == newPlayer.Team);
            
            if (sameTeam >= 2)
            {
                WeakReferenceMessenger.Default.Send("Max 2 player from same team.");
                return false;
            }

            if (newPlayer.Buyingprice > UserTeam.Budget)
            {
                WeakReferenceMessenger.Default.Send("Not enough budget.");
                return false;
            }

            var roleexist = userTeam.Roster.Any(p => p.Role == newPlayer.Role);
            if (roleexist)
            {
                WeakReferenceMessenger.Default.Send($"You already have a {newPlayer.Role} in your team.");
                return false;
            }


            return true;

        }

        [RelayCommand]
        private void AddPlayer(Player newPlayer)
        {
            if (CanAddPlayer(newPlayer))
            {
                userTeam.Roster.Add(newPlayer);
                UserTeam.Budget -= newPlayer.Buyingprice;

            }
        }



        [RelayCommand]
        private void RemovePlayer(Player player)
        {
            userTeam.Roster.Remove(player);
            UserTeam.Budget += player.Sellingprice;

        }


    }
}
