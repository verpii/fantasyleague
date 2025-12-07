using CommunityToolkit.Mvvm.Messaging;
using fantasyleague.VM;

namespace fantasyleague.V;

public partial class Market : ContentPage
{
	private MarketViewModel viewModel;

	public Market(MarketViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

        WeakReferenceMessenger.Default.Register<string>(this, async (recipient, msg) =>
        {
            await DisplayAlert("Warning", msg, "OK");
        });

    }

}