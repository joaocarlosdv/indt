namespace Contratacao.Domain.Interfaces
{
    public interface IContratacaoRepository
    {
        Task<List<Models.Contratacao>> Listar();
        Task<Models.Contratacao> ConsultarPorId(int id);
        Task<Models.Contratacao> Inserir(Models.Contratacao contratacao);
        Task<Models.Contratacao> Alterar(Models.Contratacao contratacao);
    }
}
