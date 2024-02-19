using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrilhaApiDesafio.Models
{
    public class TarefaModel
    {
        [Required] // Indica que essa propriedade é obrigatória na tabela
        [Column("Titulo")] // Indica que essa propriedade mapeia a coluna Titulo na tabela
        public string Titulo { get; set; }

        [Column("Descricao")] // Indica que essa propriedade mapeia a coluna Descricao na tabela
        public string Descricao { get; set; }

        [Column("Data")] // Indica que essa propriedade mapeia a coluna Data na tabela
        public DateTime Data { get; set; }

        [Column("Status")] // Indica que essa propriedade mapeia a coluna Status na tabela
        public EnumStatusTarefa Status { get; set; }
    }
}
