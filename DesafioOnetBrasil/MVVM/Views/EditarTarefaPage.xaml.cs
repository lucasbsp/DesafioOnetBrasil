using DesafioOnetBrasil.Services.Interfaces;
using DesafioOnetBrasil.ViewModels;

namespace DesafioOnetBrasil.Views;

public partial class EditarTarefaPage : ContentPage
{
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