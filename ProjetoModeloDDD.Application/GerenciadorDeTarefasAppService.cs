using System.Collections.Generic;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Application
{
    public class GerenciadorDeTarefasAppService : AppServiceBase<GerenciadorDeTarefas>, IGerenciadorDeTarefasAppService
    {
        private readonly IGerenciadorDeTarefasService _gerenciadordetarefasService;

        public GerenciadorDeTarefasAppService(IGerenciadorDeTarefasService gerenciadordetarefasService)
            : base(gerenciadordetarefasService)
        {
            _gerenciadordetarefasService = gerenciadordetarefasService;
        }

        public IEnumerable<GerenciadorDeTarefas> BuscarPorNome(string nome)
        {
            return _gerenciadordetarefasService.BuscarPorNome(nome);
        }
    }
}
