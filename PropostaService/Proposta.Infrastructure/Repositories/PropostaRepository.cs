using Microsoft.EntityFrameworkCore;
using Proposta.Domain.Interfaces;
using Proposta.Infrastructure.Persistence;

namespace Proposta.Infrastructure.Repositories
{
    public class PropostaRepository : IPropostaRepository
    {
        public readonly ApiContext _dbContext;
        protected DbSet<Domain.Models.Proposta> DbSet => _dbContext.Set<Domain.Models.Proposta>();

        public PropostaRepository(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<List<Domain.Models.Proposta>> Listar()
        { 
            try
            {  
                var dados = await _dbContext.Set<Domain.Models.Proposta>()
                    .AsNoTracking()
                    .ToListAsync();

                return dados;
            }
            catch (Exception)
            {
                return new List<Domain.Models.Proposta>();
            }
        }

        public virtual async Task<Domain.Models.Proposta> ConsultarPorId(int id)
        {
            try
            {
                var dado = await _dbContext.Set<Domain.Models.Proposta>()
                    .Where(x => x.Id == id)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                return dado;
            }
            catch (Exception)
            {
                return new Domain.Models.Proposta();
            }
        }

        public virtual async Task<Domain.Models.Proposta> Inserir(Domain.Models.Proposta proposta)
        {
            try
            {
                _dbContext.Set<Domain.Models.Proposta>().Add(proposta);
                await _dbContext.SaveChangesAsync();

                return proposta;
            }
            catch (Exception)
            {
                return proposta;
            }
        }

        public virtual async Task<Domain.Models.Proposta> Alterar(Domain.Models.Proposta proposta)
        {
            try
            {
                var entry = _dbContext.Entry(proposta);
                entry.State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                return proposta;
            }
            catch (Exception)
            {
                return proposta;
            }
        }
    }
}
