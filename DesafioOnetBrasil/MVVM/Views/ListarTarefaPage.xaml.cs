using DesafioOnetBrasil.Models;
using DesafioOnetBrasil.Services.Interfaces;
using DesafioOnetBrasil.ViewModels;

namespace DesafioOnetBrasil.Views;

[QueryProperty(nameof(Refresh), "Refresh")]
public partial class ListarTarefaPage : ContentPage
{
    private readonly ListarTarefaViewModel _viewModel;
    public bool Refresh { get; set; }

    /// <summary>
    /// Construtor
    /// </summary>
    /// <param name="tarefaService"></param>
    public ListarTarefaPage(ITarefaService tarefaService)
    {
        InitializeComponent();
        
        _viewModel = new ListarTarefaViewModel(tarefaService);
        
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (Refresh == true)
        {
            if (_viewModel.RefreshCommand.CanExecute(null) == true)
                _viewModel.RefreshCommand.Execute(null);
        }
    }

    /// <summary>
    /// Acesso para a página de Edição
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void OnItemTapped(object sender, EventArgs e)
    {
        if (sender is StackLayout layout && layout.BindingContext is TarefaModel item)
        {
            // Obtém o objeto Tarefa 
            var navigationParameter = new Dictionary<string, object> { { "Tarefa", item } };

            // Naveção Shell: Vai para a página de Edição
            await Shell.Current.GoToAsync($"EditarTarefa?TarefaId={item.Id}", navigationParameter);
        }
    }
}
