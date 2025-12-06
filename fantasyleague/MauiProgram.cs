using fantasyleague.DB;
using fantasyleague.V;
using fantasyleague.VM;
using Microsoft.Extensions.Logging;

namespace fantasyleague
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

           



            builder.Services.AddSingleton<IDbService, DbService>();
            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<MyTeamPage>();
            builder.Services.AddTransient<Market>();
            builder.Services.AddTransient<MarketViewModel>();



            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
