namespace ProjetoModeloDDD.Domain.Entities
{
    public class CorretoraDeImoveis
    {
        public int CorretoraDeImoveisID { get; set; }
        public string Endereco { get; set; }
        public double Preco { get; set; }
        public string Tipo { get; set; }
        public bool Ativo { get; set; }
    }
}
