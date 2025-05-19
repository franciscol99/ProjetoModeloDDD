using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface IGerenciadorDeTarefasService : IServiceBase<GerenciadorDeTarefas>
    {
        IEnumerable<GerenciadorDeTarefas> BuscarPorNome(string nome);
    }
}
