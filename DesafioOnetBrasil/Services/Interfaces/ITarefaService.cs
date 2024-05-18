using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioOnetBrasil.Services.Interfaces
{
    public interface ITarefaService
    {
        Task<List<Model.TarefaModel>> GetTarefas();
    }
}
