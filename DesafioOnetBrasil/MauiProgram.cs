using DesafioOnetBrasil.Services.Implementations;
using DesafioOnetBrasil.Services.Interfaces;
using DesafioOnetBrasil.Views;
using DesafioOnetBrasil.ViewModels;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;
using CommunityToolkit.Maui;

namespace DesafioOnetBrasil
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcon");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            // Registro de Serviços
            builder.Services.AddSingleton<ITarefaService, TarefaService>();

            // Workaround para o Shell, pois ele não possui suporte para injeção de dependência
            builder.Services.AddTransient<ListarTarefaPage>();
            builder.Services.AddTransient<EditarTarefaPage>();


            return builder.Build();
        }
    }
}
