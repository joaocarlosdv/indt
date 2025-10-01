namespace Contratacao.Domain.Models
{
    public class Proposta
    {
        public int? Id { get; set; }
        public string? Cliente { get; set; }
        public decimal? Valor { get; set; }
        public int? Status { get; set; }
    }
}
