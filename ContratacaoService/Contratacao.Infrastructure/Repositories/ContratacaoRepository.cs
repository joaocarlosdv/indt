using Contratacao.Domain.Interfaces;
using Contratacao.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Contratacao.Infrastructure.Repositories
{
    public class ContratacaoRepository : IContratacaoRepository
    {
        public readonly ApiContext _dbContext;
        protected DbSet<Domain.Models.Contratacao> DbSet => _dbContext.Set<Domain.Models.Contratacao>();

        public ContratacaoRepository(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<List<Domain.Models.Contratacao>> Listar()
        {
            try
            {
                var dados = await _dbContext.Set<Domain.Models.Contratacao>()
                    .AsNoTracking()
                    .ToListAsync();

                return dados;
            }
            catch (Exception)
            {
                return new List<Domain.Models.Contratacao>();
            }
        }

        public virtual async Task<Domain.Models.Contratacao> ConsultarPorId(int id)
        {
            try
            {
                var dado = await _dbContext.Set<Domain.Models.Contratacao>()
                    .Where(x => x.Id == id)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                return dado;
            }
            catch (Exception)
            {
                return new Domain.Models.Contratacao();
            }
        }

        public virtual async Task<Domain.Models.Contratacao> Inserir(Domain.Models.Contratacao contratacao)
        {
            try
            {
                _dbContext.Set<Domain.Models.Contratacao>().Add(contratacao);
                await _dbContext.SaveChangesAsync();

                return contratacao;
            }
            catch (Exception)
            {
                return contratacao;
            }
        }

        public virtual async Task<Domain.Models.Contratacao> Alterar(Domain.Models.Contratacao contratacao)
        {
            try
            {
                var entry = _dbContext.Entry(contratacao);
                entry.State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                return contratacao;
            }
            catch (Exception)
            {
                return contratacao;
            }
        }
    }
}
