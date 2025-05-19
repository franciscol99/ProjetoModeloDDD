using System;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class GerenciadorDeTarefas
    {
        public int GerenciadorDeTarefasID { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}
