using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class GerenciadoDeTarefasService : ServiceBase<GerenciadorDeTarefas>, IGerenciadorDeTarefasService
    {
        private readonly IGerenciadorDeTarefasRepository _gerenciadodetarefasRepository;

        public GerenciadoDeTarefasService(IGerenciadorDeTarefasRepository gerenciadodetarefasRepository)
            : base(gerenciadodetarefasRepository)
        {
            _gerenciadodetarefasRepository = gerenciadodetarefasRepository;
        }

        public IEnumerable<GerenciadorDeTarefas> BuscarPorNome(string nome)
        {
            return _gerenciadodetarefasRepository.BuscarPorNome(nome);
        }
    }
}
