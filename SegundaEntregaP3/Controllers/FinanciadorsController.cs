using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Obligatorio2.Models;

namespace SegundaEntregaP3.Controllers
{
    public class FinanciadorsController : Controller
    {
        private ObligatorioContext db = new ObligatorioContext();

        // GET: Financiadors
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["usuarioLog"] == null)
            {
                return RedirectToAction("LoginUsuario", "Usuarios");
            }
            return View(db.Financiadores.ToList());
        }

        // GET: Financiadors/Details/5
        [HttpPost]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Financiador financiador = db.Financiadores.Find(id);
            if (financiador == null)
            {
                return HttpNotFound();
            }
            return View(financiador);
        }

        // GET: Financiadors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Financiadors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,Contrasenia,Empresa,MontoAInvertir")] Financiador financiador)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ObligatorioContext())
                {
                    try
                    {
                        var fi = db.Financiadores.Where(f => f.Email == financiador.Email).ToList();
                        if (fi.Count() == 0)
                        {
                            db.Usuarios.Add(financiador);
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.mensaje = "El usuario que intenta ingresar ya existe";
                            return View();
                        }
                    }catch(Exception ex)
                    {
                        ViewBag.mensaje = "No se pudo realizar la accion, Error: " + ex;
                        return View();
                    }
                }
            }

            return View(financiador);
        }

        // GET: Financiadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["usuarioLog"] != null) {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Financiador financiador = db.Financiadores.Find(id);
            if (financiador == null)
            {
                return HttpNotFound();
            }
            return View(financiador);
        }
        return RedirectToAction("LoginUsuario","Usuarios");
        }

        // POST: Financiadors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Contrasenia,Empresa,MontoAInvertir")] Financiador financiador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(financiador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(financiador);
        }

        // GET: Financiadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["usuarioLog"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Financiador financiador = db.Financiadores.Find(id);
                if (financiador == null)
                {
                    return HttpNotFound();
                }
                return View(financiador);
            }
            return RedirectToAction("LoginUsuario", "Usuario");
        }

        // POST: Financiadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Financiador financiador = db.Financiadores.Find(id);
            db.Usuarios.Remove(financiador);
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
    }
}
