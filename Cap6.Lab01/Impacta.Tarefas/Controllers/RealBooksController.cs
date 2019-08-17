using Impacta.Tarefas.Business;
using Impacta.Tarefas.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Impacta.Tarefas.Controllers
{
    public class RealBooksController : Controller
    {
        // GET: RealBooks
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarNovasEditoras()
        {
	        EditoraBusiness editoraBusiness = new EditoraBusiness();

	        var listaEditora = editoraBusiness.ListarEditoras();

	        return View(listaEditora);

		}

        // GET: RealBooks/Details/5
        public ActionResult Details(int id)
        {
			EditoraBusiness editoraBusiness = new EditoraBusiness();

			var editora = editoraBusiness.ObterEditora(id);

			return View(editora);
		}

        // GET: RealBooks/Create
        public ActionResult Create()
        {
			EditoraBusiness editoraBusiness = new EditoraBusiness();

			return View();
        }

        // POST: RealBooks/Create
        [HttpPost]
        public ActionResult Create(Editora editora)
        {
            try
            {
				EditoraBusiness editoraBusiness = new EditoraBusiness();

				editoraBusiness.CriarEditora(editora);


				return RedirectToAction("ListarNovasEditoras");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: RealBooks/Edit/5
        public ActionResult Edit(int id)
        {
			EditoraBusiness editoraBusiness = new EditoraBusiness();

			var editora = editoraBusiness.ObterEditora(id);

			return View(editora);
        }

        // POST: RealBooks/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Editora editora)
        {
            try
            {
				EditoraBusiness editoraBusiness = new EditoraBusiness();

				editoraBusiness.AlterarEditora(editora);

				return RedirectToAction("ListarNovasEditoras");
            }
            catch
            {
                return View();
            }
        }

        // GET: RealBooks/Delete/5
        public ActionResult Delete(int id)
        {
			EditoraBusiness editoraBusiness = new EditoraBusiness();

			var editora = editoraBusiness.ObterEditora(id);

			return View(editora);
        }

        // POST: RealBooks/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
				EditoraBusiness editoraBusiness = new EditoraBusiness();

				editoraBusiness.ExcluirEditora(id);

				return RedirectToAction("ListarNovasEditoras");
            }
            catch
            {
                return View();
            }
        }
    }
}
