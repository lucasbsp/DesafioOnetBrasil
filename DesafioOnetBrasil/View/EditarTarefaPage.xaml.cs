using DesafioOnetBrasil.ViewModel;

namespace DesafioOnetBrasil.View;

public partial class EditarTarefaPage : ContentPage
{
	public EditarTarefaPage(EditarTarefaViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
    }
}