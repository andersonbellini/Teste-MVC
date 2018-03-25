using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteMVC.Models
{
    public class Emprestimo
    {
        [Key]
        public int EmprestimoID { get; set; }
        
        public int AmigoID { get; set; }

       
        public int JogoID { get; set; } 

        [Required(ErrorMessage = "O campo data é obrigatório.")]
        public string Data { get; set; }

        public virtual Amigo Amigo { get; set; }
        public virtual Jogo Jogo { get; set; }
    }
}