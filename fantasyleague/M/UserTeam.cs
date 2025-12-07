using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Text.Json;

namespace fantasyleague.M
{

    public partial class UserTeam : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ObservableProperty]
        string username;

        [ObservableProperty]
        string userid;

        [ObservableProperty]
        int budget;

        [ObservableProperty]
        string teamName;

       // [ObservableProperty]
       // int playerid;

        [ObservableProperty]
        string kepUrl;


        [ObservableProperty]
        string rosterString;


        [ObservableProperty]
        int currentPoints;


        //public List<Player> Roster
        //{
        //    get => JsonSerializer.Deserialize<List<Player>>(RosterJson) ?? new List<Player>();
        //    set => RosterJson = JsonSerializer.Serialize(value);
        //}


    }
}
