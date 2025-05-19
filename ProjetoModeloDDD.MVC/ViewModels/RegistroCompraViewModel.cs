using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class RegistroCompraViewModel
    {
        [Key]
        public int RegistroCompraID { get; set; }

        [Required(ErrorMessage = "Preencha o Valor total da compra")]
        [DataType(DataType.Currency)]
        [DisplayName("Valor total")]
        public double ValorTotal { get; set; }
        public int Quantidade { get; set; }
        public int Produto { get; set; }

        [DisplayName("Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        public virtual IEnumerable<ProdutoViewModel> ListaProdutos { get; set; }
        public virtual ProdutoViewModel Produtos { get; set; }

    }
}