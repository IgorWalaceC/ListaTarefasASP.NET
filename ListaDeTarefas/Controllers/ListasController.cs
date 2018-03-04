using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ListaDeTarefas.Models;

namespace ListaDeTarefas.Controllers
{
    public class ListasController : Controller
    {
        private TarefaContexto db = new TarefaContexto();

        // GET: Listas
        public ActionResult Index()
        {
            var listas = db.Listas.Include(l => l.Usuario);
            return View(listas.ToList());
        }

        // GET: Listas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista lista = db.Listas.Find(id);
            if (lista == null)
            {
                return HttpNotFound();
            }
            return View(lista);
        }

        // GET: Listas/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioId", "Email");
            return View();
        }

        // POST: Listas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ListaId,Nome,Ativa,UsuarioID")] Lista lista)
        {
            if (ModelState.IsValid)
            {
                db.Listas.Add(lista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioId", "Email", lista.UsuarioID);
            return View(lista);
        }

        // GET: Listas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista lista = db.Listas.Find(id);
            if (lista == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioId", "Email", lista.UsuarioID);
            return View(lista);
        }

        // POST: Listas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ListaId,Nome,Ativa,UsuarioID")] Lista lista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioId", "Email", lista.UsuarioID);
            return View(lista);
        }

        // GET: Listas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista lista = db.Listas.Find(id);
            if (lista == null)
            {
                return HttpNotFound();
            }
            return View(lista);
        }

        // POST: Listas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lista lista = db.Listas.Find(id);
            db.Listas.Remove(lista);
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
