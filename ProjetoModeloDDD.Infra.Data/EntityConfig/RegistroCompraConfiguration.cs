using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class RegistroCompraConfiguration : EntityTypeConfiguration<RegistroCompra>
    {
        public RegistroCompraConfiguration()
        {
            HasKey(p => p.RegistroCompraID);

            Property(p => p.DataCadastro)
                .IsRequired();

            Property(p => p.ValorTotal)
                .IsRequired();

            Property(p => p.Quantidade)
                .IsRequired();

            Property(p => p.Produto)
                .IsRequired();


        }
    }
}
