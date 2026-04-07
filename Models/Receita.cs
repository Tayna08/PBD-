namespace ApiFinanceiro.Models
{
    public class Receita
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public required string Descricao { get; set; }

        public required string Categoria { get; set; }

        public required decimal Valor { get; set; }

        public required DateOnly DataPrevisao { get; set; }

        public string? Observacao { get; set; }

        public required string Situacao { get; set; }

        public DateTime? DataRecebimento { get; set; }
    }
}