using DesafioOnetBrasil.View;

namespace DesafioOnetBrasil
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("ListarTarefa", typeof(ListarTarefaPage));
            Routing.RegisterRoute("EditarTarefa", typeof(EditarTarefaPage));
        }
    }
}
