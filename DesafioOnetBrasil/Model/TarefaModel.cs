using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioOnetBrasil.Model
{
    public class TarefaModel
    {
        public string? Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public string? DataCadastroFormatado { get => DataCadastro.ToString("dd/MM/yyyy"); }
        public string? Status { get; set; }
        public string? Prioridade { get; set; }
    }
}
