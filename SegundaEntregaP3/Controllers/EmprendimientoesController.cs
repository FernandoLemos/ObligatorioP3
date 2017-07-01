using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Obligatorio2.Models;
using SegundaEntregaP3.Models;
using SegundaEntregaP3.ViewModels;

namespace SegundaEntregaP3.Controllers
{
    public class EmprendimientoesController : Controller
    {
        private ObligatorioContext db = new ObligatorioContext();

        // GET: Emprendimientoes
        [HttpGet]
        public ActionResult Index(int? opcion)
        {
            if (Session["usuarioLog"] != null)
            {
                switch (opcion)
                {
                    case 1:
                        List<Emprendimiento> listaPorCosto = EmprendimietntosSinFinanciar();
                        if (listaPorCosto != null)
                        {
                            if (listaPorCosto.Count() > 0)
                            {
                                ViewBag.NombreListado = "Emprendimientos según su presupuesto";
                                return View(listaPorCosto);
                            }
                        }
                        else
                            ViewBag.mensaje = "No se encontro ningun Emprendimiento";
                        break;
                    case 2:
                        List<Emprendimiento> listaMejores = ListarMejores();
                        if (listaMejores != null)
                        {
                            if (listaMejores.Count() > 0)
                            {
                                ViewBag.NombreListado = "Emprendimientos mejores puntuados";
                                return View(listaMejores);
                            }
                        }
                        else
                            ViewBag.mensaje = "No se encontro ningun Emprendimiento";
                        break;
                    case 3:
                        List<Emprendimiento> listarSinFinanciamiento = EmprendimietntosSinFinanciamiento();
                        if (listarSinFinanciamiento != null)
                        {
                            if (listarSinFinanciamiento.Count() > 0)
                            {
                                ViewBag.NombreListado = "Emprendimientos sin financiamiento";
                                return View(listarSinFinanciamiento);
                            }
                        }
                        else
                            ViewBag.mensaje = "No se encontro ningun Emprendimiento";
                        break;
                    case 4:
                        List<Emprendimiento> emprendimientosFinanciados = EmprendimientosConFinanciador();
                        if (emprendimientosFinanciados != null)
                        {
                            if (emprendimientosFinanciados.Count() >= 0)
                            {
                                ViewBag.NombreListado = "Emprendimientos Financiados";
                                return View(emprendimientosFinanciados);
                            }
                        }
                        else
                        {
                            ViewBag.mensaje = "No Fue posible realizar la accion";
                            return View();
                        }
                        break;
                    default:
                        List<Emprendimiento> emprendimientosPropios= EmprendimientosPropios();
                        if (emprendimientosPropios != null)
                        {
                            if (emprendimientosPropios.Count() >= 0)
                            {
                                ViewBag.NombreListado = "Emprendimientos Propios";
                                return View(emprendimientosPropios);
                            }
                        }
                        else
                        {
                            ViewBag.mensaje = "No Fue posible realizar la accion";
                            return View();
                        }
                        break;
                }
            }
            else
            {
                switch (opcion)
                {
                    case 3:
                        List<Emprendimiento> listarSinFinanciamiento = EmprendimietntosSinFinanciamiento();
                        if (listarSinFinanciamiento != null)
                        {
                            if (listarSinFinanciamiento.Count() > 0)
                            {
                                ViewBag.NombreListado = "Emprendimientos sin financiamiento";
                                return View(listarSinFinanciamiento);
                            }
                        }
                        else
                            ViewBag.mensaje = "No se encontro ningun Emprendimiento";
                        break;
                    case 4:
                        List<Emprendimiento> emprendimientosFinanciados = EmprendimientosConFinanciador();
                        if (emprendimientosFinanciados != null)
                        {
                            if (emprendimientosFinanciados.Count() >= 0)
                            {
                                ViewBag.NombreListado = "Emprendimientos Financiados";
                                return View(emprendimientosFinanciados);
                            }
                        }
                        else
                        {
                            ViewBag.mensaje = "No Fue posible realizar la accion";
                            return View();
                        }
                        break;
                    default:
                        break;
                }
            }
            return View();
        }

        //public ActionResult Index(int? opcion)
        //{

        //    switch (opcion)
        //    {
        //        case 1: return View(EmprendimietntosSinFinanciar().ToListAsync());
        //    }

        //    return View();
        //}

        // GET: Emprendimientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprendimiento emprendimiento = db.Emprendimientos.Find(id);
            if (emprendimiento == null)
            {
                return HttpNotFound();
            }
            return View(emprendimiento);
        }

        // GET: Emprendimientoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emprendimientoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Costo,DuracionPrevista,Puntaje,Descripcion")] Emprendimiento emprendimiento)
        {
            if (ModelState.IsValid)
            {
                db.Emprendimientos.Add(emprendimiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emprendimiento);
        }

        // GET: Emprendimientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprendimiento emprendimiento = db.Emprendimientos.Find(id);
            if (emprendimiento == null)
            {
                return HttpNotFound();
            }
            return View(emprendimiento);
        }

        // POST: Emprendimientoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Costo,DuracionPrevista,Puntaje,Descripcion")] Emprendimiento emprendimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emprendimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emprendimiento);
        }

        // GET: Emprendimientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprendimiento emprendimiento = db.Emprendimientos.Find(id);
            if (emprendimiento == null)
            {
                return HttpNotFound();
            }
            return View(emprendimiento);
        }

        // POST: Emprendimientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emprendimiento emprendimiento = db.Emprendimientos.Find(id);
            db.Emprendimientos.Remove(emprendimiento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Financiar(int? id)
        {
            using (var db = new ObligatorioContext())
            {

                try
                {
                    var financiado = db.Financiamientos.Where(f => f.Emprendimiento.Id == id).ToList();
                    if (financiado.Count() == 0)
                    {
                        if (Session["usuarioLog"] != null)
                        {
                            string usuario = Session["usuarioLog"].ToString();
                            Emprendimiento emp = db.Emprendimientos.Find(id);
                            Financiador fin = db.Financiadores.Where(u => u.Email == usuario).Select(u => u).ToList().FirstOrDefault();
                            //int idUs = idUsuario.First();
                            //Usuario fin = db.Usuarios.Find(idUs);
                            if (emp != null && fin != null)
                            {
                                if (fin.MontoAInvertir >= emp.Costo)
                                {
                                    Financiamiento financiamiento = new Financiamiento();
                                    financiamiento.Emprendimiento = emp;
                                    financiamiento.Financiador = fin;
                                    db.Financiamientos.Add(financiamiento);
                                    db.SaveChanges();
                                    ViewBag.Titulo = "Financiamiento Aprobado !!!";
                                    ViewBag.mensaje = "Gracias por utilizar nuestro sistema";
                                    return View("Financiar");
                                }else
                                {
                                    ViewBag.Titulo = "El monto del E,prendimiento es superior a lo que usted dispone";
                                    ViewBag.mensaje = "No fue posible realizar la accion";
                                    return View("Financiar");
                                }

                            }
                            else
                            {
                                ViewBag.Titulo = "Operacion Fallida!!!";

                                ViewBag.mensaje = "No Fue posible realizar la acción";
                            }
                        }
                        else
                        {
                            ViewBag.Titulo = "Debe estar logueado para realizar esta acción";

                            ViewBag.mensaje = "No se pudo realizar la acción";
                        }
                    }
                    else
                    {
                        ViewBag.Titulo = "El Emprendimiento ya se encuentra dentro de un proceso de financiamiento";

                        ViewBag.mensaje = "No se pudo realizar la acción";
                    }
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.mensaje = "La Operacion  no puedo ser realizada debido a " + ex;
                    return View();
                }
            }

            return View();
        }

        //public ActionResult FiltrarPorCosto(string FiltrarPorCosto1, string FiltrarPorCosto2)
        //{
        //    if (FiltrarPorCosto1 != "" && FiltrarPorCosto2 != "")
        //    {
        //        decimal costoFiltro1 = decimal.Parse(FiltrarPorCosto1);
        //        decimal costoFiltro2 = decimal.Parse(FiltrarPorCosto2);

        //        using (var db = new ObligatorioContext())
        //        {
        //            try
        //            {
        //                var empredimientos = db.Emprendimientos.Where(e => e.Costo <= costoFiltro1 && e.Costo >= costoFiltro2).OrderByDescending(e => e.Costo);
        //                if (empredimientos.Count() > 0)
        //                {
        //                    return View(empredimientos.ToList());
        //                }
        //                else
        //                {
        //                    ViewBag.mensaje = "No se encontro Ningun Emprendimiento";
        //                    return View(ViewBag);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                ViewBag.mensaje = "La Operacion  no puedo ser realizada debido a " + ex;
        //                return View(ViewBag);
        //            }
        //        }
        //    }
        //    ViewBag.mensaje = "No se encontro Ningun Emprendimiento";
        //    return View(ViewBag);
        //}
        public List<Emprendimiento> EmprendimietntosSinFinanciar()
        {
            using (var db = new ObligatorioContext())
            {
                try
                {
                    string correo = Session["usuarioLog"].ToString();
                    var u = db.Financiadores.Where(f => f.Email == correo).ToList();
                    Financiador fi = u.FirstOrDefault();
                    var emprendimientos = (from e in db.Emprendimientos where e.Costo <= fi.MontoAInvertir select e).Except(from e in db.Emprendimientos
                                                                                                                            join f in db.Financiamientos on e.Id equals f.Emprendimiento.Id
                                                                                                                            select e);

                    return emprendimientos.ToList();
                }
                catch (Exception ex)
                {

                }
            }


            return null;
        }

        public List<Emprendimiento> ListarMejores()
        {
            using (var db = new ObligatorioContext())
            {
                try
                {

                    int cantidad = (db.Emprendimientos.Count() * 10) / 100;
                    var emprendimientos = db.Emprendimientos.OrderByDescending(e => e.Puntaje).Except(from e in db.Emprendimientos
                                                                                                      join f in db.Financiamientos on e.Id equals f.Emprendimiento.Id
                                                                                                      select e);
                    ;
                    return emprendimientos.ToList().GetRange(1, cantidad);


                }
                catch (Exception ex)
                {

                }
            }
            return null;
        }
        [HttpGet]
        public ActionResult FiltrarPorCosto()
        {
            using (var db = new ObligatorioContext())
            {
                try
                {
                    List<Emprendimiento> emprendimientos = (db.Emprendimientos.Select(e => e).Except(from e in db.Emprendimientos
                                                                                                     join f in db.Financiamientos on e.Id equals f.Emprendimiento.Id
                                                                                                     select e)).ToList();
                    if (emprendimientos != null && emprendimientos.Count() > 0)
                    {
                        ViewBag.emprendimientos = emprendimientos;
                        return View(ViewBag.emprendimientos);
                    }
                    ViewBag.mensaje = "No se encontro ningún emprendimiento que cumpla con los criterios de busqueda";
                    return View(ViewBag.mensaje);
                }
                catch (Exception ex)
                {
                    ViewBag.mensaje = "No se puedo realizar la accion, Error: " + ex;
                }
            }
            ViewBag.mensaje = "No se encontro ningún emprendimiento que cumpla con los criterios de busqueda";
            return View();
        }
        [HttpPost]
        public ActionResult FiltrarPorCosto(string duracionf, string costo1f, string costo2f)
        {
            if (duracionf != "" && costo1f != "" && costo2f != "")
            {
                int duracion = int.Parse(duracionf);
                decimal costo1 = decimal.Parse(costo1f);
                decimal costo2 = decimal.Parse(costo2f);

                using (var db = new ObligatorioContext())
                {
                    try
                    {
                        if (Session["emprendimientos"] != null)
                        {
                            List<Emprendimiento> emprendimientos = Session["emprendimientos"] as List<Emprendimiento>;
                            //var emprendimientosFiltrados = emprendimientos.Select(e => e);
                            var emprendimientosFiltrados = emprendimientos.Where(e => e.Costo <= costo1 && e.Costo >= costo2 && e.DuracionPrevista <= duracion).OrderByDescending(e => e.DuracionPrevista);


                            if (emprendimientosFiltrados != null && emprendimientosFiltrados.Count() > 0)
                            {
                                ViewBag.emprendimientos = emprendimientos;
                                return View(emprendimientosFiltrados.ToList());
                            }
                            ViewBag.mensaje = "No se encontro ningún emprendimiento que cumpla con los criterios de busqueda";
                            return View();
                        }
                        else
                            return RedirectToAction("FiltrarPorCosto", "Emprendimientoes");
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
            ViewBag.mensaje = "No pueden haber campos vacios en la busqueda";
            return RedirectToAction("FiltrarPorCosto", "Emprendimientoes");
        }
        public List<Emprendimiento> EmprendimietntosSinFinanciamiento()
        {
            using (var db = new ObligatorioContext())
            {
                try
                {

                    var emprendimientos = (from e in db.Emprendimientos select e).Except(from e in db.Emprendimientos
                                                                                         join f in db.Financiamientos on e.Id equals f.Emprendimiento.Id
                                                                                         select e);

                    return emprendimientos.ToList();
                }
                catch (Exception ex)
                {
                    ViewBag.mensaje = "No se puedo realizar la accion, Error: " + ex;
                }
            }


            return null;
        }

        public List<Emprendimiento> EmprendimientosConFinanciador()
        {
            List<EmprendimientoViewModel> empRet = new List<EmprendimientoViewModel>();
            using (var db = new ObligatorioContext())
            {
                try
                {
                    var emprendimientos = (from e in db.Emprendimientos
                                           join f in db.Financiamientos on e.Id equals f.Emprendimiento.Id
                                           select e).ToList();

                    if (emprendimientos.Count() > 0)
                    {



                        //var u = db.Financiadores.Where(f => f.Id == fi.Financiador.Id).ToList();
                        //var fin = u.FirstOrDefault();
                        ////Financiador financiador = db.Financiadores.Where(f=>f.Id==1).ToList().FirstOrDefault();
                        //EmprendimientoViewModel emp = new EmprendimientoViewModel(emprendimiento, fin ,fi);

                        //empRet.Add(emp);
                        return emprendimientos;
                    }

                }
                catch (Exception ex)
                {

                }
            }

            return null;
        }

        public ActionResult Salir()
        {
            Session["usuarioLog"] = null;
            return RedirectToAction("LoginUsuario", "Usuarios");
        }
        public List<Emprendimiento> EmprendimientosPropios()
        {
            using (var db = new ObligatorioContext())
            {
                try
                {
                    string correo = Session["usuarioLog"].ToString();
                    var empredimientos = (from a in db.Financiamientos
                                          join e in db.Emprendimientos on a.Emprendimiento.Id equals e.Id
                                          join f in db.Usuarios on a.Financiador.Id equals f.Id
                                          where f.Email == correo
                                          select e);
                    if (empredimientos != null && empredimientos.Count() > 0)
                    {
                        ViewBag.NombreListado = "Emprendimientos Financiados";
                        return empredimientos.ToList();
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.mensaje = "La Operacion  no puedo ser realizada debido, Error: " + ex;
                    return null;
                }
            }
            return null;
        }
    }

}
