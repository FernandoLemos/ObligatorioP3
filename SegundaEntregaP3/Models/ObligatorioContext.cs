using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using SegundaEntregaP3.Models;

namespace Obligatorio2.Models
{
    public class ObligatorioContext:DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Financiador> Financiadores{ get; set; }
        public DbSet<Emprendimiento> Emprendimientos{ get; set; }
        public DbSet<Financiamiento> Financiamientos { get; set; }
        public ObligatorioContext():base("conexionSegundaEntrega")
        {
            Database.SetInitializer<ObligatorioContext>(new CreateDatabaseIfNotExists<ObligatorioContext>());
        }
    }
}