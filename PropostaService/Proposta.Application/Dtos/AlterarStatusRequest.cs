using Proposta.Application.Enums;

namespace Proposta.Application.Dtos
{
    public class AlterarStatusRequest
    {
        public int Id { get; set; }
        public StatusPropostaEnum NovoStatus { get; set; }
    }
}
