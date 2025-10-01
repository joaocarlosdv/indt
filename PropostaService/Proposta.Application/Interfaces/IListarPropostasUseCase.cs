using Proposta.Application.Dtos;

namespace Proposta.Application.Interfaces
{
    public interface IListarPropostasUseCase
    {
        Task<List<PropostaResponse>> ExecutarAsync();
    }
}
