using Microsoft.EntityFrameworkCore;
using Proposta.Infrastructure.Configure;

namespace Proposta.Infrastructure.Persistence
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        public DbSet<Domain.Models.Proposta> Proposta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PropostaConfigure());

            base.OnModelCreating(modelBuilder);
        }
    }
}
