using __XamlGeneratedCode__;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using DesafioOnetBrasil.Models;
using DesafioOnetBrasil.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesafioOnetBrasil.ViewModels
{
    public partial class ListarTarefaViewModel : ObservableObject
    {
        #region Propriedades

        private readonly ITarefaService _tarefaService;

        [ObservableProperty]
        private ObservableCollection<TarefaModel> _tarefas = [];

        [ObservableProperty]
        private bool _isRefreshing;

        [ObservableProperty]
        private bool _isEmptyList;
        
        public ICommand AdicionarTarefaCommand => new Command(AdicionarTarefa);
        public ICommand EditarTarefaCommand => new Command<TarefaModel>(EditarTarefa);
        public ICommand RefreshCommand => new Command(Refresh);
        public ICommand ExcluirTarefaCommand => new Command<TarefaModel>(ExcluirTarefa);

        #endregion

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="tarefaService"></param>
        public ListarTarefaViewModel(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
            ObterListaTarefas();
        }
        
        #region Métodos

        /// <summary>
        /// Obtém uma lista de tarefas 
        /// </summary>
        private async void ObterListaTarefas()
        {
            try
            {
                // Obtém tarefas do banco de dados
                await _tarefaService.InitializeAsync();
                var tarefasList = await _tarefaService.ReadTarefas();

                // Popula a tela com os registros do banco de dados
                Tarefas = new ObservableCollection<TarefaModel>();
                foreach (var tarefa in tarefasList)
                {
                    Tarefas.Add(tarefa);
                }

                // Confere se precisa exibir a mensagem "Nenhuma terefa encontrada"
                if (Tarefas == null || Tarefas.Count <= 0)
                {
                    IsEmptyList = true;
                }
                else
                {
                    IsEmptyList = false;
                }
            }
            catch (Exception e)
            {
                DisplayErrorMessage($"Não foi possível obter a lista de tarefas. Erro [{e.Message}]");
            }
        }

        /// <summary>
        /// Navega para a tela de adicionar uma nova tarefa
        /// </summary>
        private async void AdicionarTarefa()
        {
            await Shell.Current.GoToAsync("EditarTarefa");
        }

        /// <summary>
        /// Altera as informações de uma tarefa
        /// </summary>
        private async void EditarTarefa(TarefaModel tarefa)
        {
            // Obtém a tarefa selecionada
            var navigationParameter = new Dictionary<string, object> { { "Tarefa", tarefa } };

            // Naveção Shell: Vai para a página de Edição
            await Shell.Current.GoToAsync($"EditarTarefa", navigationParameter);
        }

        /// <summary>
        /// Exclui uma tarefa
        /// </summary>
        private async void ExcluirTarefa(TarefaModel tarefa)
        {
            if (tarefa != null && tarefa.Id != 0)
            {
                if (App.Current != null && App.Current.MainPage != null)
                {
                    bool confirm = await App.Current.MainPage.DisplayAlert("Confirmação", "Deseja excluir essa tarefa?", "Sim", "Não");
                    if (confirm)
                    {
                        try
                        {
                            await _tarefaService.InitializeAsync();
                            await _tarefaService.DeleteTarefa(tarefa);

                            Refresh();

                            DisplaySimpleSuccessMessage("Tarefa excluída");
                        }
                        catch (Exception e)
                        {
                            DisplayErrorMessage($"Não foi possível excluir a tarefa. Erro [{e.Message}].");
                        }
                    }
                }
                else
                    DisplayErrorMessage("Não foi possível excluir a tarefa. Objeto [App.Current.MainPage] está nulo.");
            }
            else
                DisplayErrorMessage("Não foi possível excluir a tarefa. Objeto [Tarefa] está nulo.");
        }

        /// <summary>
        /// Exibe uma mensagem no estilo Snackbar
        /// </summary>
        /// <param name="msg"></param>
        private void DisplayErrorMessage(string msg)
        {
            if (App.Current != null && App.Current.MainPage != null)
            {
                var snackbar = Snackbar.Make(
                    "Ops... Houve um erro. Toque em 'Ver mais' para saber mais detalhes.",
                    () => App.Current.MainPage.DisplayAlert("Detalhes do Erro", msg, "Ok"),
                    "Ver mais",
                    TimeSpan.FromSeconds(5),
                    new CommunityToolkit.Maui.Core.SnackbarOptions
                    {
                        BackgroundColor = Color.FromArgb("F9CF58"),
                        TextColor = Colors.Black
                    }
                );
                snackbar.Show();
            }
        }

        /// <summary>
        /// Exibe uma mensagem simples de sucesso no estilo Snackbar
        /// </summary>
        /// <param name="msg"></param>
        private void DisplaySimpleSuccessMessage(string msg)
        {
            if (App.Current != null && App.Current.MainPage != null)
            {
                var snackbar = Snackbar.Make(
                    msg,
                    null,
                    string.Empty,
                    TimeSpan.FromSeconds(2),
                    new CommunityToolkit.Maui.Core.SnackbarOptions
                    {
                        BackgroundColor = Color.FromArgb("249689"),
                        TextColor = Colors.White
                    }
                );
                snackbar.Show();
            }
        }

        /// <summary>
        /// Método chamado para a funcionalidade 'Pull To Refresh'
        /// </summary>
        private void Refresh()
        {
            IsRefreshing = true;
            ObterListaTarefas();
            IsRefreshing = false;
        }
        
        #endregion


    }
}
