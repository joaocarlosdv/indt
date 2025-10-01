using Proposta.Application.Dtos;

namespace Proposta.Application.Interfaces
{
    public interface IConsultarStatusPropostaUseCase
    {
        Task<PropostaResponse> ExecutarAsync(int id);
    }
}
