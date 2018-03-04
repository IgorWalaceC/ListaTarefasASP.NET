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
    public class TarefasController : Controller
    {
        private TarefaContexto db = new TarefaContexto();

        // GET: Tarefas
        public ActionResult Index()
        {
            var tarefas = db.Tarefas.Include(t => t.lista);
            return View(tarefas.ToList());
        }

        // GET: Tarefas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefa tarefa = db.Tarefas.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            return View(tarefa);
        }

        // GET: Tarefas/Create
        public ActionResult Create()
        {
            ViewBag.ListaId = new SelectList(db.Listas, "ListaId", "Nome");
            return View();
        }

        // POST: Tarefas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TarefaId,Nome,Concluida,Ativa,ListaId")] Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                db.Tarefas.Add(tarefa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ListaId = new SelectList(db.Listas, "ListaId", "Nome", tarefa.ListaId);
            return View(tarefa);
        }

        // GET: Tarefas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefa tarefa = db.Tarefas.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListaId = new SelectList(db.Listas, "ListaId", "Nome", tarefa.ListaId);
            return View(tarefa);
        }

        // POST: Tarefas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TarefaId,Nome,Concluida,Ativa,ListaId")] Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarefa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListaId = new SelectList(db.Listas, "ListaId", "Nome", tarefa.ListaId);
            return View(tarefa);
        }

        // GET: Tarefas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefa tarefa = db.Tarefas.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            return View(tarefa);
        }

        // POST: Tarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tarefa tarefa = db.Tarefas.Find(id);
            db.Tarefas.Remove(tarefa);
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
