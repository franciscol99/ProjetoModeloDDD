using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class AgendaTelefonicaConfiguration : EntityTypeConfiguration<AgendaTelefonica>
    {
        public AgendaTelefonicaConfiguration()
        {
            HasKey(p => p.AgendaTelefonicaID);

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(200);

            Property(p => p.Telefone)
               .IsRequired()
               .HasMaxLength(20);

            Property(p => p.Email)
              .IsRequired()
              .HasMaxLength(200);
        }
    }
}
