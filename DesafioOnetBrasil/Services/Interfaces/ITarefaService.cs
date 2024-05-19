using DesafioOnetBrasil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioOnetBrasil.Services.Interfaces
{
    public interface ITarefaService
    {
        Task InitializeAsync();
        Task<int> CreateTarefa(TarefaModel tarefa);
        Task<List<TarefaModel>> ReadTarefas();
        Task<int> UpdateTarefa(TarefaModel tarefa);
        Task<int> DeleteTarefa(TarefaModel tarefa);
    }
}
