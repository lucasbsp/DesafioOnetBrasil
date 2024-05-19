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
        private readonly ITarefaService _tarefaService;

        [ObservableProperty]
        private TarefaModel _tarefa;
        public string Title { get; private set; }
        public ICommand SalvarTarefaCommand { get; private set; }
        public ICommand ExcluirTarefaCommand { get; private set; }

        /// <summary>
        /// Construtor
        /// </summary>
        public EditarTarefaViewModel(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
            Title = "Adicionar Tarefa";
            Tarefa = new TarefaModel();

            SalvarTarefaCommand = new Command(SalvarTarefa);
            ExcluirTarefaCommand = new Command(ExcluirTarefa);
        }

        /// <summary>
        /// Obtêm os dados passados por parâmetro, e define o título da página
        /// </summary>
        /// <param name="query"></param>
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query != null && query.Count > 0)
            {
                Tarefa = query["Tarefa"] as TarefaModel ?? new TarefaModel();

                if (Tarefa.Id != 0)
                {
                    Title = Tarefa.Nome;
                }
                else
                {
                    Title = "Editar Tarefa";
                }
            }
        }

        /// <summary>
        /// Salva os dados de uma tarefa
        /// </summary>
        private async void SalvarTarefa()
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

            // Adicionar tarefa
            if (Tarefa.Id == 0)
            {
                try
                {
                    Tarefa.DataCadastro = DateTime.Now;

                    await _tarefaService.InitializeAsync();
                    await _tarefaService.CreateTarefa(Tarefa);
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
                    Tarefa.DataCadastro = DateTime.Now;
                    
                    await _tarefaService.InitializeAsync();
                    await _tarefaService.UpdateTarefa(Tarefa);
                }
                catch (Exception e)
                {
                    DisplayErrorMessage($"Não foi possível editar a tarefa. Erro [{e.Message}].");
                }
            }
                
            await Shell.Current.GoToAsync("..?Refresh=true", true);
        }

        /// <summary>
        /// Exclui uma tarefa
        /// </summary>
        private async void ExcluirTarefa()
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
                            await _tarefaService.InitializeAsync();
                            await _tarefaService.DeleteTarefa(Tarefa);
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
    }
}
