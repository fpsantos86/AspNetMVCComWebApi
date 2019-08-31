using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Impacta.Tarefas.Core.Models;

namespace Impacta.Tarefas.Controllers
{
    public class AutenticadorController : Controller
    {
        // GET: Autenticador
        public ActionResult Formulario()
        {
            return View();
        }

        public ActionResult Entrar(Usuario usuario)
        {
	        if (usuario.UserName != null && usuario.Password != null && 
	            usuario.UserName.Equals("Felipe") && usuario.Password.Equals("RealBooks"))
	        {
		        Session["Usuario"] = usuario;
		        return RedirectToAction("Index", "RealBooks");
	        }
	        else
	        {
		        ViewBag.Mensagem = " usuário ou senha incorretos ";
		        return View("Formulário");
	        }
        }

        public ActionResult Sair()
        {
			Session.Abandon();
			return RedirectToAction("Formulario", "Autenticador");
        }
    }
}