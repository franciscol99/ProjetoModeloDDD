using System.Collections.Generic;
using System.Linq;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class AgendaRepository : RepositoryBase<Agenda>, IAgendaRepository
    {
        public IEnumerable<Agenda> BuscarPorNome(string nome)
        {
            return Db.Agendas.Where(p => p.Nome == nome);
        }
    }
}
