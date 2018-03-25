using TesteMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TesteMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
            {
               
                return View();
            }
            else
            {
                return RedirectToAction("login");
            }
        }    

        public ActionResult Login(Usuario u)
        {
            // esta action trata o post (login)
            if (ModelState.IsValid) //verifica se é válido
            {
                using (DBContext  dc = new DBContext())
                {
                    var v = dc.Usuarios.Where(a => a.NomeUsuario.Equals(u.NomeUsuario) && a.Senha.Equals(u.Senha)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["usuarioLogadoID"] = v.Id.ToString();
                        Session["nomeUsuarioLogado"] = v.NomeUsuario.ToString();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(u);
        }
    }
}