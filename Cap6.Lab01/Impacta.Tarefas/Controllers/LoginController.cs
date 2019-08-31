using System.Web.Mvc;

using System.Web.Security;
using Impacta.Tarefas.Core.Models;

namespace Impacta.Tarefas.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Autenticacao()
        {
			Usuario usuario = null;

            return View(usuario);
        }

		public ActionResult AutenticarLogin(Usuario usuario)
		{
			FormsAuthentication.SetAuthCookie(usuario.UserName, false);

			return RedirectToAction("Index","RealBooks");
		}
		public ActionResult Logout()
		{
			FormsAuthentication.SignOut();

			return View("Autenticacao");
		}

	}
}