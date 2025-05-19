using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class CorretoraDeImoveisViewModel
    {

        [Key]
        public int CorretoraDeImoveisID { get; set; }

        [DisplayName("Endereço")]
        [Required(ErrorMessage = "Preencha o Endereço")]
        [MaxLength(300, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        public string Endereco { get; set; }


        [Required(ErrorMessage = "Preencha o Tipo")]
        [MaxLength(200, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        public string Tipo { get; set; }

        [DisplayName("Preço")]
        [Required(ErrorMessage = "Preencha o Preço")]
        [DisplayFormat(DataFormatString = "R$ {0:n}")]
        public double Preco { get; set; }
    }
}