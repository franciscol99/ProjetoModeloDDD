
using System;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Musica
    {
        public int MusicaID { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Gravadora { get; set; }
        public DateTime Lancamento { get; set; }
    }
}
