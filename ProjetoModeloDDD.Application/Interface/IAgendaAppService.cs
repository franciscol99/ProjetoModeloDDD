using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface IAgendaAppService : IAppServiceBase<Agenda>
    {
        IEnumerable<Agenda> BuscarPorNome(string nome);
    }
}
