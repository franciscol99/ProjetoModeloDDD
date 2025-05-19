namespace ProjetoModeloDDD.Domain.Entities
{
    public class Produto
    {
        public int ProdutoID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string CodigoFabrica { get; set; }
        public double valorCompra { get; set; }
        public double valorVenda { get; set; }
        public int Estoque { get; set; }
        public int EstoqueMin {  get; set; }
        public int Fabricante {  get; set; }
        public bool ativo { get; set; }

        public int RegistroCompraID { get; set; }
        //public virtual RegistroCompra RegistroCompra { get; set; }

    }
}
