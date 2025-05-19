using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class CorretoraDeImoveisService : ServiceBase<CorretoraDeImoveis>, ICorretoraDeImoveisService
    {
        private readonly ICorretoraDeImoveisRepository _corretoradeimoveisRepository;

        public CorretoraDeImoveisService(ICorretoraDeImoveisRepository corretoradeimoveisRepository)
            : base(corretoradeimoveisRepository)
        {
            _corretoradeimoveisRepository = corretoradeimoveisRepository;
        }

        public IEnumerable<CorretoraDeImoveis> BuscarPorNome(string nome)
        {
            return _corretoradeimoveisRepository.BuscarPorNome(nome);
        }
    }
}
