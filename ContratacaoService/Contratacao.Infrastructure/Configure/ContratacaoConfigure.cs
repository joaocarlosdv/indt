using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacao.Infrastructure.Configure
{
    public class ContratacaoConfigure : IEntityTypeConfiguration<Domain.Models.Contratacao>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Contratacao> builder)
        {
            builder.ToTable("contratacao");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
        }
    }
}
