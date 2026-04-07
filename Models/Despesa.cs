using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiFinanceiro.Models
{
    [Table("despesas"),PrimaryKey(nameof(Id))]
    public class Despesa
    {

        [Column("id")]
        public  int Id { get; set; }

        [Column("descricao")]
        public required string Descricao { get; set; }

        [Column("categoria")]
        public required string Categoria { get; set; }

        [Column("valor")]
        public required decimal Valor { get; set; }

        [Column("dataVencimento")]
        public required DateOnly DataVencimento { get; set; }

        [Column("dataPag")]
        public DateTime? DataPagamento { get; set; }

        [Column("situacao")]
        public required string Situacao { get; set; }
        
    }
}
