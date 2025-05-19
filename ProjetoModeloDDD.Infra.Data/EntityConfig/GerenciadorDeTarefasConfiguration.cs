using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class GerenciadorDeTarefasConfiguration : EntityTypeConfiguration<GerenciadorDeTarefas>
    {
        public GerenciadorDeTarefasConfiguration()
        {
            HasKey(p => p.GerenciadorDeTarefasID);

            Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(300);

            Property(p => p.DataVencimento)
               .IsRequired();
        }
    }
}
