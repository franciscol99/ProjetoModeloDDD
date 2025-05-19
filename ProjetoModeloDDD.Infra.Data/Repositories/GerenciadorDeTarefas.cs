using System.Collections.Generic;
using System.Linq;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class GerenciadorDeTarefasRepository : RepositoryBase<GerenciadorDeTarefas>, IGerenciadorDeTarefasRepository
    {
        public IEnumerable<GerenciadorDeTarefas> BuscarPorNome(string nome)
        {
            return Db.GerenciadorDeTarefas.Where(p => p.Descricao == nome);
        }
    }
}
