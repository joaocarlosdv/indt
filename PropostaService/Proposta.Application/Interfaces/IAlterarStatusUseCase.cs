using Proposta.Application.Dtos;

namespace Proposta.Application.Interfaces
{
    public interface IAlterarStatusUseCase
    {
        Task<AlterarStatusResponse> ExecutarAsync(AlterarStatusRequest request);
    }
}
