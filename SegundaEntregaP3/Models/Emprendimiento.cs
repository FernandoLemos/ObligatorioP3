using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obligatorio2.Models
{
    public class Emprendimiento
    {
        public int Id { get; set; }
        public int CodigoEmprendimiento { get; set; }
        public string Titulo { get; set; }
        public decimal Costo { get; set; }
        public int DuracionPrevista { get; set; }
        public int Puntaje { get; set; }
        public string Descripcion { get; set; }


        public bool CargarEmprendimientos(string ruta)
        {
            bool ret = false;
            FileStream miArchivo = new FileStream(ruta, FileMode.Open);
            StreamReader sr = new StreamReader(miArchivo);
            string linea;
            using (var db = new ObligatorioContext())
            {
                if (Database.Exists("ObligatorioSgundaEntrega"))
                {
                    if (db.Emprendimientos.Count() == 0)
                    {
                        while ((linea = sr.ReadLine()) != null)
                        {
                            Emprendimiento emprendimiento = new Emprendimiento();
                            string[] datos = linea.Split('#');
                            emprendimiento.CodigoEmprendimiento = int.Parse(datos[0]);
                            emprendimiento.Titulo = datos[1];
                            emprendimiento.Costo = decimal.Parse(datos[2]);
                            emprendimiento.DuracionPrevista = int.Parse(datos[3]);
                            emprendimiento.Puntaje = int.Parse(datos[4]);
                            emprendimiento.Descripcion = datos[5];
                            db.Entry(emprendimiento).State = EntityState.Unchanged;
                            db.Emprendimientos.Add(emprendimiento);
                        }

                        db.SaveChanges();
                        ret = true;
                    }
                }
            }
        
            return ret;
        }
}

}