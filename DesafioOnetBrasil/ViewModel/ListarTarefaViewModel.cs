using __XamlGeneratedCode__;
using DesafioOnetBrasil.Model;
using DesafioOnetBrasil.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesafioOnetBrasil.ViewModel
{
    public class ListarTarefaViewModel
    {
        #region Propriedades

        private readonly ITarefaService _tarefaService;
        public ObservableCollection<TarefaModel> Tarefas { get; set; } = [];
        public ICommand AdicionarTarefaCommand { get; private set; }

        #endregion

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="tarefaService"></param>
        public ListarTarefaViewModel(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
            AdicionarTarefaCommand = new Command(AdicionarTarefa);

            ObterListaTarefas();
        }
        
        #region Métodos

        /// <summary>
        /// Obtém uma lista de tarefas 
        /// </summary>
        private async void ObterListaTarefas()
        {
            var tarefasList = await _tarefaService.GetTarefas();

            foreach (var tarefa in tarefasList)
            {
                Tarefas.Add(tarefa);
            }
        }

        /// <summary>
        /// Navega para a tela de adicionar uma nova tarefa
        /// </summary>
        private async void AdicionarTarefa()
        {
            await Shell.Current.GoToAsync("EditarTarefa");
        }

        #endregion


    }
}
