using Proposta.Application.Enums;

namespace Proposta.Application.Dtos
{
    public class CriarPropostaRequest
    {
        public int? Id { get; set; }
        public string? Cliente { get; set; }
        public decimal? Valor { get; set; }
        public StatusPropostaEnum? Status { get; set; }
    }
}
