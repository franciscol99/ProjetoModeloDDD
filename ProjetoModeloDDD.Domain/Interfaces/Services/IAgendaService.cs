using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface IAgendaService : IServiceBase<Agenda>
    {
        IEnumerable<Agenda> BuscarPorNome(string nome);
    }
}
