using Contratacao.Application.Dtos;

namespace Contratacao.Application.Interfaces
{
    public interface IContratarPropostaUseCase
    {
        Task<ContratacaoResponse> ExecutarAsync(ContratacaoRequest request);
    }
}
