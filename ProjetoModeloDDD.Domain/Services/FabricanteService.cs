using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class FabricanteService : ServiceBase<Fabricante>, IFabricanteService
    {
        private readonly IFabricanteRepository _fabricanteRepository;

        public FabricanteService(IFabricanteRepository fabricanteRepository)
            : base(fabricanteRepository)
        {
            _fabricanteRepository = fabricanteRepository;
        }

        public IEnumerable<Fabricante> BuscarPorNome(string nome)
        {
            return _fabricanteRepository.BuscarPorNome(nome);
        }
    }
}
