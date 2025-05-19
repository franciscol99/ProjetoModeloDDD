using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface IAgendaTelefonicaService : IServiceBase<AgendaTelefonica>
    {
        IEnumerable<AgendaTelefonica> BuscarPorNome(string nome);
    }
}
