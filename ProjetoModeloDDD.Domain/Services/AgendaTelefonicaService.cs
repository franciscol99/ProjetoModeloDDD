using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class AgendaTelefonicaService : ServiceBase<AgendaTelefonica>, IAgendaTelefonicaService
    {
        private readonly IAgendaTelefonicaRepository _agendatelefonicaRepository;

        public AgendaTelefonicaService(IAgendaTelefonicaRepository agendatelefonicaRepository)
            : base(agendatelefonicaRepository)
        {
            _agendatelefonicaRepository = agendatelefonicaRepository;
        }

        public IEnumerable<AgendaTelefonica> BuscarPorNome(string nome)
        {
            return _agendatelefonicaRepository.BuscarPorNome(nome);
        }
    }
}
