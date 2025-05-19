using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface IGerenciadorDeTarefasAppService : IAppServiceBase<GerenciadorDeTarefas>
    {
        IEnumerable<GerenciadorDeTarefas> BuscarPorNome(string nome);
    }
}
