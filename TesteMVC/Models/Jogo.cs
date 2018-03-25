using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteMVC.Models
{
    public class Jogo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Titulo é obrigatório.")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Estilo é obrigatório.")]
        public string Estilo { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public string Lancamento { get; set; }

        public virtual ICollection<Emprestimo> Emprestimo { get; set; }

    }
}