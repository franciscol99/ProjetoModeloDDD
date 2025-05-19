using System.Collections.Generic;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Application
{
    public class RegistroCompraAppService : AppServiceBase<RegistroCompra>, IRegistroCompraAppService
    {
        private readonly IRegistroCompraService _registrocompraService;

        public RegistroCompraAppService(IRegistroCompraService registrocompraService)
            : base(registrocompraService)
        {
            _registrocompraService = registrocompraService;
        }

        public IEnumerable<RegistroCompra> BuscarPorNome(string nome)
        {
            return _registrocompraService.BuscarPorNome(nome);
        }
    }
}
