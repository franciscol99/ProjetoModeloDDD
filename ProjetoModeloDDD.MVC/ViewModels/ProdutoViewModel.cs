using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class ProdutoViewModel
    {
        private string descricao;
        private string codigoFabrica;
        private int estoqueMin;
        [Key]
        [DisplayName("ID")]
        public int ProdutoID { get; set; }

        [DisplayName("Fabricante")]
        public int Fabricante { get; set; }

        [Required(ErrorMessage = "Insira um nome")]
        [MinLength(3, ErrorMessage = "Mínimo de 3 caracteres")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insira uma descrição")]
        [MinLength(2, ErrorMessage = "Mínimo de 2 caracteres")]
        [MaxLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [DisplayName("Descrição do produto")]
        public string Descricao { get => descricao; set => descricao = value; }

        [Required(ErrorMessage = "Insira um código de fábrica")]
        [MinLength(2, ErrorMessage = "Mínimo de 2 caracteres")]
        [MaxLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [DisplayName("Código de Fábrica")]
        public string CodigoFabrica { get => codigoFabrica; set => codigoFabrica = value; }

        [DisplayName("Valor de Compra")]
        //[RegularExpression(@"^\((\d{10}?)\)$", ErrorMessage = "Insira apenas números")]
        [Required(ErrorMessage = "Insira um valor de compra")]
        [DisplayFormat(DataFormatString = "R$ {0:n}")]
        public double valorCompra { get; set; }

        [DisplayName("Valor de Venda")]
        //[RegularExpression(@"^\((\d{10}?)\)$", ErrorMessage = "Insira apenas números")]
        [Required(ErrorMessage = "Insira um valor de venda")]
        [DisplayFormat(DataFormatString = "R$ {0:n}")]
        public double ValorVenda { get; set; }

        [DisplayName("Estoque")]
        [Required(ErrorMessage = "Insira o estoque")]
        public int Estoque { get; set; }

        [DisplayName("Estoque mínimo")]
        [Required(ErrorMessage = "Insira o estoque mínimo")]
        public int EstoqueMin { get => estoqueMin; set => estoqueMin = value; }

        [DisplayName("Ativo")]
        public bool ativo { get; set; }

        //public int RegistroCompraID { get; set; }

        //public virtual RegistroCompra RegistroCompra { get; set; }
    }

}