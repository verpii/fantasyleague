using CommunityToolkit.Mvvm.Messaging;

namespace fantasyleague
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
            WeakReferenceMessenger.Default.Register<string>(this, async (r, m) =>
            {
                await DisplayAlert("Warning", m, "OK");
            });
        }

        
    }
}
