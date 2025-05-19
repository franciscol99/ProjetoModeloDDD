using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class RegistroCompraService : ServiceBase<RegistroCompra>, IRegistroCompraService
    {
        private readonly IRegistroCompraRepository _registrocompraRepository;

        public RegistroCompraService(IRegistroCompraRepository registrocompraRepository)
            : base(registrocompraRepository)
        {
            _registrocompraRepository = registrocompraRepository;
        }

        public IEnumerable<RegistroCompra> BuscarPorNome(string nome)
        {
            return _registrocompraRepository.BuscarPorNome(nome);
        }
    }
}
