using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class CarroViewModel
    {

        [Key]
        public int CarroID { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(200, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Autor")]
        [MaxLength(200, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Preencha a velocidade do carro")]
        public float Velocidade { get; set; }

        [Required(ErrorMessage = "Preencha o Ano do carro")]
        public float Ano { get; set; }
    }
}