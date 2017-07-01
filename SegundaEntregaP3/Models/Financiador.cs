using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obligatorio2.Models
{
    public class Financiador : Usuario
    {
        
        //public string UsuarioId{ get; set; }
        [Required(ErrorMessage = "Debe Ingresar el nombre de una empresa")]
        [MaxLength(20)]
        public string Empresa { get; set; }
        [Required]
        public decimal MontoAInvertir { get; set; }
    }
}