using Proposta.Application.Dtos;

namespace Proposta.Application.Interfaces
{
    public interface ICriarPropostaUseCase
    {
        Task<CriarPropostaResponse> ExecutarAsync(CriarPropostaRequest request);
    }
}
