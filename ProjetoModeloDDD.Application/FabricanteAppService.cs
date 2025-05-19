using System.Collections.Generic;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Application
{
    public class FabricanteAppService : AppServiceBase<Fabricante>, IFabricanteAppService
    {
        private readonly IFabricanteService _fabricanteService;

        public FabricanteAppService(IFabricanteService fabricanteService)
            : base(fabricanteService)
        {
            _fabricanteService = fabricanteService;
        }

        public IEnumerable<Fabricante> BuscarPorNome(string nome)
        {
            return _fabricanteService.BuscarPorNome(nome);
        }
    }
}
