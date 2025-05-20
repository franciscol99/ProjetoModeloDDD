using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class GerenciadorDeTarefasViewModel
    {
        [Key]
        [DisplayName("ID")]
        public int GerenciadorDeTarefasID { get; set; }

        [Required(ErrorMessage = "Insira uma descrição")]
        [MinLength(2, ErrorMessage = "Mínimo de 2 caracteres")]
        [MaxLength(300, ErrorMessage = "Máximo de 300 caracteres")]
        [DisplayName("Descrição da tarefa")]
        public string Descricao { get; set; }

        [DisplayName("Data de vencimento")]
        [Required(ErrorMessage = "Insira uma data")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataVencimento { get; set; }

    }
}