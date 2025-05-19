using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class MusicaService : ServiceBase<Musica>, IMusicaService
    {
        private readonly IMusicaRepository _musicaRepository;

        public MusicaService(IMusicaRepository musicaRepository)
            : base(musicaRepository)
        {
            _musicaRepository = musicaRepository;
        }

        public IEnumerable<Musica> BuscarPorNome(string nome)
        {
            return _musicaRepository.BuscarPorNome(nome);
        }
    }
}
