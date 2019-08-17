using Impacta.Tarefas.Core.Models;
using Impacta.Tarefas.DAL;
using Impacta.Tarefas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Impacta.Tarefas.Controllers
{
    public class TarefaController : Controller
    {
        // GET: Tarefa
        public ActionResult Index()
        {
            return View();
        }


		public ActionResult NovaTarefa()
		{
			return View();
		}

		[HttpPost]
		public ActionResult NovaTarefa(TarefaViewModel tarefaView)
		{
			if (ModelState.IsValid)
			{
				Data objData = new Data();
				Tarefa tarefa = new Tarefa();

				tarefa.Nome = tarefaView.Nome;
				tarefa.Prioridade = tarefaView.Prioridade;
				tarefa.Concluida = tarefaView.Concluida;
				tarefa.Observacao = tarefaView.Observacao;

				var resultado = objData.CriarTarefa(tarefa);

				return RedirectToAction("ListarNovasTarefas");
			}
			else
			{
				ViewBag.Alerta = "Por favor verificar os dados do formulario";
			}

			return View();

		}

		public ActionResult ListarNovasTarefas() {

			List<Tarefa> tarefas = null;

			try
			{
				Data data = new Data();
				tarefas = data.ListarTarefas();

			}
			catch (Exception ex)
			{

				ViewBag.Alerta = "Ops! Verifique: " + ex.Message;
			}

			return View(tarefas);
			
		}



		// GET: Tarefa/Details/5
		public ActionResult Details(int id)
        {
			Data data = new Data();
			var tarefa = data.ConsultarTarefa(id);

			return View(tarefa);
		}

        // GET: Tarefa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tarefa/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tarefa/Edit/5
        public ActionResult Edit(int id)
        {
			Data data = new Data();

			var tarefa = data.ConsultarTarefa(id);

			if (tarefa == null) {
				ViewBag.Alerta = "Não foi encontrado o registro desejado";

				return View("ListarNovasTarefas");
			}

            return View(tarefa);
        }

        // POST: Tarefa/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Tarefa tarefa)
        {
			if (ModelState.IsValid)
			{
				Data objData = new Data();

				var resultado = objData.AtualizarTarefa(tarefa);

				return RedirectToAction("ListarNovasTarefas");
			}
			else
			{
				ViewBag.Alerta = "Por favor verificar os dados do formulario";
			}

			return View();
		}

        // GET: Tarefa/Delete/5
        public ActionResult Delete(int id)
        {
			Data data = new Data();
			var tarefa = data.ConsultarTarefa(id);

			return View(tarefa);
        }

        // POST: Tarefa/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
				// TODO: Add delete logic here

				Data objData = new Data();

				var resultado = objData.DeletarTarefa(id);

				return RedirectToAction("ListarNovasTarefas");
            }
            catch
            {
                return View();
            }
        }


    }
}
