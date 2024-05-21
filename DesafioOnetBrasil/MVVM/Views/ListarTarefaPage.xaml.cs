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

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_viewModel.OrdenarTarefasCommand.CanExecute(null) == true)
        {
            _viewModel.OrdenarTarefasCommand.Execute(null);
        }
    }
}
