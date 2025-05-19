using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class AnimalConfiguration : EntityTypeConfiguration<Animal>
    {
        public AnimalConfiguration()
        {
            HasKey(p => p.AnimalID);

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(200);

            Property(p => p.Especie)
               .IsRequired()
               .HasMaxLength(200);

            Property(p => p.Som)
              .HasMaxLength(100);

            Property(p => p.Idade)
               .IsRequired();

        }
    }
}
