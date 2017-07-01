using Obligatorio2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SegundaEntregaP3.Models
{
    public class Financiamiento
    {
        public int Id{ get; set; }
        public Usuario Financiador { get; set; }
        public Emprendimiento Emprendimiento { get; set; }
    }
}