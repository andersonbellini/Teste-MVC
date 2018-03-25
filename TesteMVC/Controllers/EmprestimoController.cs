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
    public class EmprestimoController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Emprestimo
        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                var emprestimos = db.Emprestimos.Include(e => e.Amigo).Include(e => e.Jogo);

                var Jogolivre = db.Jogos.Where(g => !db.Emprestimos.Any(e => e.JogoID == g.Id));


                if (Jogolivre.ToList().Count() == 0)
                {

                    ViewBag.Message = "Não há mais Jogos para emprestar, resgate algum!";
                    return View(emprestimos.ToList());
                }
                else
                {
                    return View(emprestimos.ToList());
                }
            }
            else
            {
                return RedirectToAction("login", "Home");
            }
          
        }

        // GET: Emprestimo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimos.Find(id);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            return View(emprestimo);
        }

        // GET: Emprestimo/Create
        public ActionResult Create()
        {
            ViewBag.AmigoID = new SelectList(db.Amigos, "Id", "Nome");


            var Jogolivre = db.Jogos.Where(g => !db.Emprestimos.Any(e => e.JogoID == g.Id));                            

            
           if (Jogolivre.ToList().Count() == 0)
            {

                ViewBag.Message = "Não há mais Jogos para emprestar!";
                return RedirectToAction("Index", "Emprestimo");
            }


            ViewBag.JogoID = new SelectList(Jogolivre, "Id", "Titulo");
            return View();
        }

        // POST: Emprestimo/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmprestimoID,AmigoID,JogoID,Data")] Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                db.Emprestimos.Add(emprestimo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AmigoID = new SelectList(db.Amigos, "Id", "Nome", emprestimo.AmigoID);
            ViewBag.JogoID = new SelectList(db.Jogos, "Id", "Titulo", emprestimo.JogoID);
            return View(emprestimo);
        }

        // GET: Emprestimo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimos.Find(id);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            ViewBag.AmigoID = new SelectList(db.Amigos, "Id", "Nome", emprestimo.AmigoID);
            ViewBag.JogoID = new SelectList(db.Jogos, "Id", "Titulo", emprestimo.JogoID);
            return View(emprestimo);
        }

        // POST: Emprestimo/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmprestimoID,AmigoID,JogoID,Data")] Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emprestimo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AmigoID = new SelectList(db.Amigos, "Id", "Nome", emprestimo.AmigoID);
            ViewBag.JogoID = new SelectList(db.Jogos, "Id", "Titulo", emprestimo.JogoID);
            return View(emprestimo);
        }

        // GET: Emprestimo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimos.Find(id);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            return View(emprestimo);
        }

        // POST: Emprestimo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emprestimo emprestimo = db.Emprestimos.Find(id);
            db.Emprestimos.Remove(emprestimo);
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
