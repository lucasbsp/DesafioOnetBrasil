using SQLite;

namespace DesafioOnetBrasil.Models
{
    [Table("Tarefas")]
    public class TarefaModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull, MaxLength(100)]
        public string Nome { get; set; } = string.Empty;
        
        [MaxLength(250)]
        public string? Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public string DataCadastroFormatado { get => DataCadastro.ToString("dd/MM/yyyy"); }
        public string? Status { get; set; }
        public string? Prioridade { get; set; }
    }
}
