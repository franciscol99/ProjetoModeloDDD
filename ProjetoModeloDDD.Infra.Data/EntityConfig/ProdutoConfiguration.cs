using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            HasKey(p => p.ProdutoID);

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(p => p.Descricao)
               .IsRequired()
               .HasMaxLength(300);

            Property(p => p.CodigoFabrica)
                .IsRequired();

            Property(p => p.valorCompra)
                .IsRequired();

            Property(p => p.valorVenda)
                .IsRequired();

            Property(p => p.Estoque)
                .IsRequired();

            Property(p => p.EstoqueMin)
                 .IsRequired();

            Property(p => p.Fabricante);

        }
    }
}
