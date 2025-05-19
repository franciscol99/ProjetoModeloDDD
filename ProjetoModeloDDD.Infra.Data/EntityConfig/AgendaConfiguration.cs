using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class AgendaConfiguration : EntityTypeConfiguration<Agenda>
    {
        public AgendaConfiguration()
        {
            HasKey(p => p.AgendaID);

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(200);

            Property(p => p.Idade)
               .IsRequired();

            Property(p => p.Altura)
              .IsRequired();
        }
    }
}
