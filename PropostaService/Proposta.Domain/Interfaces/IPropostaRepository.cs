namespace Proposta.Domain.Interfaces
{
    public interface IPropostaRepository
    {
        Task<List<Models.Proposta>> Listar();
        Task<Domain.Models.Proposta> ConsultarPorId(int id);
        Task<Models.Proposta> Inserir(Models.Proposta proposta);
        Task<Models.Proposta> Alterar(Domain.Models.Proposta proposta);
    }
}
