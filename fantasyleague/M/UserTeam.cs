using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasyleague.M
{
    public partial class UserTeam : ObservableObject
    {
        [ObservableProperty]
        string username;

        [ObservableProperty]
        string userid;

        [ObservableProperty]
        int budget;

        [ObservableProperty]
        List<Player> roster = new List<Player>();


    }
}
