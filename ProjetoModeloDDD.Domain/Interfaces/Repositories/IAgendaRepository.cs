using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Domain.Interfaces
{

    public interface IAgendaRepository : IRepositoryBase<Agenda>
    {
        IEnumerable<Agenda> BuscarPorNome(string nome);
    }
}
