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
        private ObservableCollection<TarefaModel> _tarefas;

        [ObservableProperty]
        private bool _isRefreshing;

        public ICommand AdicionarTarefaCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }

        #endregion

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="tarefaService"></param>
        public ListarTarefaViewModel(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
            Tarefas = [];

            AdicionarTarefaCommand = new Command(AdicionarTarefa);
            RefreshCommand = new Command(Refresh);

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
                await _tarefaService.InitializeAsync();
                var tarefasList = await _tarefaService.ReadTarefas();

                Tarefas = new ObservableCollection<TarefaModel>();
                foreach (var tarefa in tarefasList)
                {
                    Tarefas.Add(tarefa);
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
