using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface IMusicaService : IServiceBase<Musica>
    {
        IEnumerable<Musica> BuscarPorNome(string nome);
    }
}
