using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class MusicaConfiguration : EntityTypeConfiguration<Musica>
    {
        public MusicaConfiguration()
        {
            HasKey(p => p.MusicaID);

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(200);

            Property(p => p.Autor)
               .IsRequired()
               .HasMaxLength(200);

            Property(p => p.Gravadora)
              .IsRequired()
              .HasMaxLength(200);

            Property(p => p.Lancamento)
                .IsRequired();
        }
    }
}
