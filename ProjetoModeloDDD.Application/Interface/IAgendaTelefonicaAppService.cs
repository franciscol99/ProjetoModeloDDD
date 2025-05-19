using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface IAgendaTelefonicaAppService : IAppServiceBase<AgendaTelefonica>
    {
        IEnumerable<AgendaTelefonica> BuscarPorNome(string nome);
    }
}
