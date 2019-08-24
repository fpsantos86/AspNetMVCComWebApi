using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using Impacta.Tarefas.Business;
using Impacta.Tarefas.Core.Models;
using Newtonsoft.Json;

namespace Impacta.Tarefas.WebApi.Controllers
{
    public class WebApiEditoraController : ApiController
    {
	    EditoraBusiness editora;

		//GET: api/WebApiEditora
		public IEnumerable<Editora> Get()
		{
			editora = new EditoraBusiness();

			var lista = editora.ListarEditoras();

			return lista;
		}

		//public JsonResult<List<Editora>> Get()
		//{
		//	editora = new EditoraBusiness();

		//	var lista = editora.ListarEditoras();

		//	return Json(lista, JsonRequestBehavior.AllowGet);
		//}


		// GET: api/WebApiEditora/5
		public Editora Get(int id)
        {
	        editora = new EditoraBusiness();
			var result = editora.ObterEditora(id);
			return result;

        }

        // POST: api/WebApiEditora
        public void Post(Editora objEditora)
        {
			editora = new EditoraBusiness();
			editora.CriarEditora(objEditora);
        }

        // PUT: api/WebApiEditora/5
        public void Put(int id, Editora objEditora)
        {
	        editora = new EditoraBusiness();

			editora.AlterarEditora(objEditora);
		}

        // DELETE: api/WebApiEditora/5
        public void Delete(int id)
        {
			editora = new EditoraBusiness();

			editora.ExcluirEditora(id);
        }
    }
}
