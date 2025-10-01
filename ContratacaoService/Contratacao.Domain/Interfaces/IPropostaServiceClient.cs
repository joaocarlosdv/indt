using Contratacao.Domain.Models;

namespace Contratacao.Domain.Interfaces
{
    public interface IPropostaServiceClient
    {
        Task<Proposta> ConsultarStatusProposta(int propostaId);
    }
}
