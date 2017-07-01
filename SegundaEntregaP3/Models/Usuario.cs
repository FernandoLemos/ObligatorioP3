using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obligatorio2.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        public int Id{ get; set; }
        [Required(ErrorMessage ="Este Campo es obligatorio")]
        [EmailAddress(ErrorMessage ="El formato no el correcto")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Debe Introducir una Contraseña con minimo 8 caracteres y maximo 15")]
        [MinLength(8),MaxLength(15)]
        public string Contrasenia { get; set; }

    }
}