using CommunityToolkit.Mvvm.ComponentModel;
using DesafioOnetBrasil.Model;
using DesafioOnetBrasil.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesafioOnetBrasil.ViewModel
{
    public class EditarTarefaViewModel : ObservableObject, IQueryAttributable
    {
        private readonly ITarefaService _tarefaService;
        public TarefaModel? Tarefa { get; private set; }
        public string? Title { get; private set; }
        public ICommand SalvarTarefaCommand { get; private set; }

        /// <summary>
        /// Construtor
        /// </summary>
        public EditarTarefaViewModel(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
            SalvarTarefaCommand = new Command(SalvarTarefa);
        }

        /// <summary>
        /// Obtém os dados passados por parâmetro 
        /// </summary>
        /// <param name="query"></param>
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.Count > 0)
            {
                Tarefa = query["Tarefa"] as TarefaModel;
                OnPropertyChanged(nameof(Tarefa));

                Title = "Editar Tarefa";
            }
            else
            {
                Tarefa = null;
                OnPropertyChanged(nameof(Tarefa));

                Title = "Adicionar Tarefa";
            }
        }

        /// <summary>
        /// Salva os dados da tarefa
        /// </summary>
        private async void SalvarTarefa()
        {
            if (Tarefa == null)
            {
                // TODO: Adicionar tarefa
                // TODO: Popular [Tarefa]
                // await _tarefaService.AdicionarTarefa(Tarefa);
            }
            else
            {
                // TODO: Editar tarefa
                // await _tarefaService.AlterarTarefa(Tarefa);
            }

            await Shell.Current.GoToAsync("..", true);
        }
    }
}
