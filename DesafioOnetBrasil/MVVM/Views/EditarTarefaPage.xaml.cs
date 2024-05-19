using DesafioOnetBrasil.Services.Interfaces;
using DesafioOnetBrasil.ViewModels;

namespace DesafioOnetBrasil.Views;

[QueryProperty(nameof(TarefaId), "TarefaId")]
public partial class EditarTarefaPage : ContentPage
{
    public int TarefaId { get; set; }

    /// <summary>
    /// Construtor
    /// </summary>
    /// <param name="tarefaService"></param>
    public EditarTarefaPage(ITarefaService tarefaService)
	{
		InitializeComponent();

		BindingContext = new EditarTarefaViewModel(tarefaService);
    }
}