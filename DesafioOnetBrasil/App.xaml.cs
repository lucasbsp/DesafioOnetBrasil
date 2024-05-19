using DesafioOnetBrasil.Services.Interfaces;

namespace DesafioOnetBrasil
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
