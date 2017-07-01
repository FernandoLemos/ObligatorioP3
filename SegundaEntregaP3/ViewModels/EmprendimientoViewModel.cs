using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SegundaEntregaP3.Models;
using Obligatorio2.Models;
using System.ComponentModel.DataAnnotations;

namespace SegundaEntregaP3.ViewModels
{
    public class EmprendimientoViewModel
    {
        [Key]
        public int ID { get; set; }
        public int EmprendimientoID { get; set; }
        public string EmprendimientoTitulo { get; set;}
        public decimal EmprendimientoCosto { get; set; }
        public int EmprendimientoDuracion { get; set; }
        public int FinanciadorID { get; set; }

        public EmprendimientoViewModel(Emprendimiento e, Financiador f,Financiamiento fi)
        {
            this.ID = fi.Id;
            this.EmprendimientoID = e.Id;
            this.EmprendimientoTitulo = e.Titulo;
            this.EmprendimientoCosto = e.Costo;
            this.EmprendimientoDuracion = e.DuracionPrevista;
            this.FinanciadorID = f.Id;
        }

    }
}