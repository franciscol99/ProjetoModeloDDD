using System.Collections.Generic;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Application
{
    public class MusicaAppService : AppServiceBase<Musica>, IMusicaAppService
    {
        private readonly IMusicaService _musicaService;

        public MusicaAppService(IMusicaService musicaService)
            : base(musicaService)
        {
            _musicaService = musicaService;
        }

        public IEnumerable<Musica> BuscarPorNome(string nome)
        {
            return _musicaService.BuscarPorNome(nome);
        }
    }
}
