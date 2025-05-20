using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class CorretoraDeImoveisConfiguration : EntityTypeConfiguration<CorretoraDeImoveis>
    {
        public CorretoraDeImoveisConfiguration()
        {
            HasKey(p => p.CorretoraDeImoveisID);

            Property(p => p.Endereco)
                .IsRequired()
                .HasMaxLength(300);

            Property(p => p.Preco)
               .IsRequired();

            Property(p => p.Tipo)
               .HasMaxLength(200);

            Property(p => p.Ativo);
        }
    }
}
