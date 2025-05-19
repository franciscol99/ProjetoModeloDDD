using System.Collections.Generic;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Domain.Services
{
    public class AgendaService : ServiceBase<Agenda>, IAgendaService
    {
        private readonly IAgendaRepository _agendaRepository;

        public AgendaService(IAgendaRepository agendaRepository)
            : base(agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }

        public IEnumerable<Agenda> BuscarPorNome(string nome)
        {
            return _agendaRepository.BuscarPorNome(nome);
        }
    }
}
