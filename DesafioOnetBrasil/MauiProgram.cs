using DesafioOnetBrasil.Services.Implementations;
using DesafioOnetBrasil.Services.Interfaces;
using DesafioOnetBrasil.View;
using DesafioOnetBrasil.ViewModel;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;

namespace DesafioOnetBrasil
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
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

            // Registro de Views
            builder.Services.AddSingleton<ListarTarefaPage>();
            builder.Services.AddSingleton<EditarTarefaPage>();

            // Registro de ViewModels
            builder.Services.AddSingleton<ListarTarefaViewModel>();
            builder.Services.AddSingleton<EditarTarefaViewModel>();

            return builder.Build();
        }
    }
}
