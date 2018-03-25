using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TesteMVC.Models;

namespace TesteMVC.Controllers
{
    public class JogoController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Jogo
        public ActionResult Index()
        {
           
            if (Session["usuarioLogadoID"] != null)
            {
                return View(db.Jogos.ToList());
            }
            else
            {
                return RedirectToAction("login", "Home");
            }
        }

        // GET: Jogo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo Jogo = db.Jogos.Find(id);
            if (Jogo == null)
            {
                return HttpNotFound();
            }
            return View(Jogo);
        }

        // GET: Jogo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jogo/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Estilo,Lancamento")] Jogo Jogo)
        {
            if (ModelState.IsValid)
            {
                db.Jogos.Add(Jogo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Jogo);
        }

        // GET: Jogo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo Jogo = db.Jogos.Find(id);
            if (Jogo == null)
            {
                return HttpNotFound();
            }
            return View(Jogo);
        }

        // POST: Jogo/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Estilo,Lancamento")] Jogo Jogo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Jogo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Jogo);
        }

        // GET: Jogo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo Jogo = db.Jogos.Find(id);
            if (Jogo == null)
            {
                return HttpNotFound();
            }
            return View(Jogo);
        }

        // POST: Jogo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jogo Jogo = db.Jogos.Find(id);
            db.Jogos.Remove(Jogo);
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
