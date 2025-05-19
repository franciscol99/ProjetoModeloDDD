using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class CarroConfiguration : EntityTypeConfiguration<Carro>
    {
        public CarroConfiguration()
        {
            HasKey(p => p.CarroID);

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(200);

            Property(p => p.Modelo)
               .IsRequired()
               .HasMaxLength(200);

            Property(p => p.Ano)
             .IsRequired();

            Property(p => p.Velocidade)
            .IsRequired();
        }
    }
}
