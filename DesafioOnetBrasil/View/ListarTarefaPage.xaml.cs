using DesafioOnetBrasil.Model;
using DesafioOnetBrasil.ViewModel;

namespace DesafioOnetBrasil.View;

public partial class ListarTarefaPage : ContentPage
{
    public ListarTarefaPage(ListarTarefaViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }

    private async void OnItemTapped(object sender, EventArgs e)
    {
        if (sender is StackLayout layout && layout.BindingContext is TarefaModel item)
        {
            var navigationParameter = new Dictionary<string, object>
                {
                    { "Tarefa", item }
                };

            await Shell.Current.GoToAsync("EditarTarefa", navigationParameter);
        }
    }
}
