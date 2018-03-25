using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TesteMVC.Models
{    
        public class Amigo
        {
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "O campo Nome é obrigatório.")]
            public string Nome { get; set; }
            [Required(ErrorMessage = "O campo Celular é obrigatório.")]
            public string Celular { get; set; }           

            public virtual ICollection<Emprestimo> Emprestimo { get; set; }
     
    }

   

}
