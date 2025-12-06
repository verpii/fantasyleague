using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace fantasyleague.M
{
    public enum PlayerRole
    {
        Top,
        Jungle,
        Mid,
        Adc,
        Support

    }
    
    public partial class Player : ObservableObject
    {

        [ObservableProperty]
        string irlName;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ObservableProperty]
        string ign;

        [ObservableProperty]
        PlayerRole role;

        [ObservableProperty]
        int sellingprice;

        [ObservableProperty]
        int buyingprice;

        [ObservableProperty]
        string team;

        [ObservableProperty]
        string imageurl;

        [ObservableProperty]
        int currentPoints;


    }
}
