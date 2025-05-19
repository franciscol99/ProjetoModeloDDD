using System.Collections.Generic;
using System.Linq;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class AgendaTelefonicaRepository : RepositoryBase<AgendaTelefonica>, IAgendaTelefonicaRepository
    {
        public IEnumerable<AgendaTelefonica> BuscarPorNome(string nome)
        {
            return Db.AgendaTelefonicas.Where(p => p.Nome == nome);
        }
    }
}
