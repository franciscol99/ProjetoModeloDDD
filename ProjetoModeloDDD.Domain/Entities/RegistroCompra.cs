using System;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class RegistroCompra
    {
        public int RegistroCompraID { get; set; }
        public virtual IEnumerable<Produto> ListaProdutos { get; set; }
        //public virtual List<Produto> ListaProdutos { get; set; }
        public double ValorTotal { get; set; }
        public int Quantidade { get; set; }
        public int Produto { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
