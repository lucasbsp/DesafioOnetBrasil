using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Converters;
using CommunityToolkit.Mvvm.ComponentModel;
using DesafioOnetBrasil.Models;
using DesafioOnetBrasil.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesafioOnetBrasil.ViewModels
{
    public partial class EditarTarefaViewModel : ObservableObject, IQueryAttributable
    {
        #region Propriedades

        private readonly ITarefaService _tarefaService;

        [ObservableProperty]
        private TarefaModel _tarefa;

        [ObservableProperty]
        private bool _isEnabledExcluirTarefa;

        [ObservableProperty]
        private bool _isLoading;

        public string Title { get; private set; }
        public ICommand SalvarTarefaCommand => new Command(SalvarTarefa);
        public ICommand ExcluirTarefaCommand => new Command(ExcluirTarefa);

        #endregion

        /// <summary>
        /// Construtor
        /// </summary>
        public EditarTarefaViewModel(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
            Title = "Adicionar Tarefa";
            Tarefa = new TarefaModel();
        }

        /// <summary>
        /// Obtêm os dados passados por parâmetro, e define o título da página
        /// </summary>
        /// <param name="query"></param>
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            // Editar Tarefa
            if (query != null && query.Count > 0)
            {
                // Recebe o parâmetro para realizar a Edição
                Tarefa = query["Tarefa"] as TarefaModel ?? new TarefaModel();

                // Title da página
                Title = Tarefa?.Nome ?? "Editar Tarefa";
                
                // Habilita o botão de Excluir Tarefa
                IsEnabledExcluirTarefa = true;
            }
        }

        /// <summary>
        /// Salva os dados de uma tarefa
        /// </summary>
        private async void SalvarTarefa()
        {
            try
            {
                // Validações do campo [Título]
                if (string.IsNullOrWhiteSpace(Tarefa.Nome))
                {
                    DisplaySimpleErrorMessage($"Campo obrigatório: Título");
                    return;
                }

                // Validações do campo [Status]
                else if (Tarefa.Status == null)
                {
                    DisplaySimpleErrorMessage($"Campo obrigatório: Status da Tarefa");
                    return;
                }

                IsLoading = true;

                // Adicionar tarefa
                if (Tarefa.Id == 0)
                {
                    try
                    {
                        Tarefa.DataCadastro = DateTime.Now;
                        Tarefa.DataAtualizacao = DateTime.Now;

                        await _tarefaService.InitializeAsync();
                        await _tarefaService.CreateTarefa(Tarefa);

                        DisplaySimpleSuccessMessage("Tarefa criada com sucesso!");
                    }
                    catch (Exception e)
                    {
                        DisplayErrorMessage($"Não foi possível adicionar a tarefa. Erro [{e.Message}].");
                    }
                }
                // Editar tarefa
                else
                {
                    try
                    {
                        Tarefa.DataAtualizacao = DateTime.Now;

                        await _tarefaService.InitializeAsync();
                        await _tarefaService.UpdateTarefa(Tarefa);

                        DisplaySimpleSuccessMessage("Tarefa atualizada com sucesso!");
                    }
                    catch (Exception e)
                    {
                        DisplayErrorMessage($"Não foi possível editar a tarefa. Erro [{e.Message}].");
                    }
                }

                await Shell.Current.GoToAsync("..?Refresh=true", true);
            }
            catch (Exception e)
            {
                DisplayErrorMessage($"Não foi possível salvar a tarefa. Erro [{e.Message}].");
            }
            finally
            {
                IsLoading = false;
            }
        }

        /// <summary>
        /// Exclui uma tarefa
        /// </summary>
        private async void ExcluirTarefa()
        {
            try
            {
                if (Tarefa != null && Tarefa.Id != 0)
                {
                    if (App.Current != null && App.Current.MainPage != null)
                    {
                        bool confirm = await App.Current.MainPage.DisplayAlert("Confirmação", "Deseja excluir essa tarefa?", "Sim", "Não");
                        if (confirm)
                        {
                            try
                            {
                                IsLoading = true;

                                await _tarefaService.InitializeAsync();
                                await _tarefaService.DeleteTarefa(Tarefa);

                                await Shell.Current.GoToAsync("..?Refresh=true", true);

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
            catch (Exception e)
            {
                DisplayErrorMessage($"Não foi possível excluir a tarefa. Erro [{e.Message}].");
            }
            finally
            {
                IsLoading = false;
            }
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
        /// Exibe uma mensagem simples de erro no estilo Snackbar
        /// </summary>
        /// <param name="msg"></param>
        private void DisplaySimpleErrorMessage(string msg)
        {
            if (App.Current != null && App.Current.MainPage != null)
            {
                var snackbar = Snackbar.Make(
                    msg,
                    null,
                    string.Empty,
                    TimeSpan.FromSeconds(4),
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
    }
}
