using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class FabricanteConfiguration : EntityTypeConfiguration<Fabricante>
    {
        public FabricanteConfiguration()
        {
            HasKey(p => p.FabricanteID);

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(200);

            Property(p => p.Endereco)
               .IsRequired()
               .HasMaxLength(300);

            Property(p => p.Cidade)
               .IsRequired()
               .HasMaxLength(100);
        }
    }
}
