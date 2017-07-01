using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Obligatorio2.Models;

namespace SegundaEntregaP3.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["usuarioLog"] == null)
            {
                return RedirectToAction("LoginUsuario", "Usuarios");
            }
            //using (var db = new ObligatorioContext())
            //{
            //    try
            //    {
            //        if (db.Emprendimientos.Count() == 0)
            //        {
            //            //int cantidad = (db.Emprendimientos.Count() * 10) / 100;
            //            //var emprendimiento = new Emprendimiento();
            //            //string ruta = HttpRuntime.AppDomainAppPath + @"\Data\Emprendimientos.txt";
            //            //emprendimiento.CargarEmprendimientos(ruta);
            //        }
            //        else
            //        {
            //        //    int cantidad = (db.Emprendimientos.Count() * 10) / 100;
            //        //    var emprendimientos = db.Emprendimientos.OrderByDescending(e => e.Puntaje);
            //        //    return View(emprendimientos.ToList().GetRange(1, cantidad));
            //        }

            //    }
            //    catch (Exception ex)
            //    {

            //    }
            //}
            return View();
        }
        [HttpPost]
        public ActionResult Index(IEnumerable<Emprendimiento> emprendimientos)
        {
            return View(emprendimientos);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Details(int? id)
        {
            return RedirectToAction("Details", "Emprendimientoes", new { id = id });
        }

    }

}