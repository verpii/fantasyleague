using fantasyleague.V;

namespace fantasyleague
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("myteam", typeof(MyTeamPage));
            Routing.RegisterRoute("market", typeof(Market));
        }
    }
}
