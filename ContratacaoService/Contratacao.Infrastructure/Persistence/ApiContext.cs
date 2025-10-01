using Contratacao.Infrastructure.Configure;
using Microsoft.EntityFrameworkCore;

namespace Contratacao.Infrastructure.Persistence
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        public DbSet<Domain.Models.Contratacao> Contratacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContratacaoConfigure());

            base.OnModelCreating(modelBuilder);
        }
    }
}
