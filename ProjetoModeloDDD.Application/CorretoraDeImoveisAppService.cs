using System.Collections.Generic;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Application
{
    public class CorretoraDeImoveisAppService : AppServiceBase<CorretoraDeImoveis>, ICorretoraDeImoveisAppService
    {
        private readonly ICorretoraDeImoveisService _corretoradeimoveisService;

        public CorretoraDeImoveisAppService(ICorretoraDeImoveisService corretoradeimoveisService)
            : base(corretoradeimoveisService)
        {
            _corretoradeimoveisService = corretoradeimoveisService;
        }

        public IEnumerable<CorretoraDeImoveis> BuscarPorNome(string nome)
        {
            return _corretoradeimoveisService.BuscarPorNome(nome);
        }
    }
}
