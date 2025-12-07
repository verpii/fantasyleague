

using fantasyleague.VM;

namespace fantasyleague.V;

public partial class MyTeamPage : ContentPage
{
	private MyTeamPageViewModel vm;

	public MyTeamPage(MyTeamPageViewModel vm)
	{

		
		InitializeComponent();
		this.vm = vm;
		BindingContext = vm;
		
	}

    private async void MainPage_OnLoaded(object? sender, EventArgs e)
    {
        await vm.LoadUserTeam();
    }
}