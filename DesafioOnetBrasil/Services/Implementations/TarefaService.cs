using DesafioOnetBrasil.Model;
using DesafioOnetBrasil.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioOnetBrasil.Services.Implementations
{
    public class TarefaService : ITarefaService
    {
        public Task<List<TarefaModel>> GetTarefas()
        {
            var tarefas = new List<TarefaModel>
            {
                new TarefaModel { Id = "1", Nome = "Tarefa 1", Descricao = "Descrição 1", DataCadastro = DateTime.Now, Status = "Completo" },
                new TarefaModel { Id = "2", Nome = "Tarefa 2", Descricao = "Descrição 2", DataCadastro = DateTime.Now, Status = "Incompleto" },
                new TarefaModel { Id = "3", Nome = "Tarefa 3", Descricao = "Descrição 3", DataCadastro = DateTime.Now, Status = "Incompleto" },
                new TarefaModel { Id = "4", Nome = "Tarefa 4", Descricao = "Descrição 4", DataCadastro = DateTime.Now, Status = "Completo" },
                new TarefaModel { Id = "5", Nome = "Tarefa 5", Descricao = "Descrição 5", DataCadastro = DateTime.Now, Status = "Completo" }
            };
            return Task.FromResult(tarefas);
        }
    }
}
