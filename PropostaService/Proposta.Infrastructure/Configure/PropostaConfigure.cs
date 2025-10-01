using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Proposta.Infrastructure.Configure
{
    public class PropostaConfigure : IEntityTypeConfiguration<Domain.Models.Proposta>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Proposta> builder)
        {
            builder.ToTable("proposta");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
        }
    }
}
