using fantasyleague.VM;

namespace fantasyleague.V;

public partial class Market : ContentPage
{
	private MarketViewModel viewModel;

	public Market(MarketViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

    }

}