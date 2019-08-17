using Impacta.Tarefas.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.Tarefas.EF
{
	public class EditoraEF
	{

		public List<Editora> ListarEditoras()
		{
			List<Editora> listaDeEditora = null;

			using (RealBooksContexto realDb = new RealBooksContexto())
			{
				listaDeEditora = realDb.Editoras.ToList();
			}

			return listaDeEditora;
		}

		public void CriarEditora(Editora editora) {

			using (var realDb = new RealBooksContexto()) {
				realDb.Editoras.Add(editora);

				realDb.SaveChanges();
			}
		}

		public void AlterarEditora(Editora editora)
		{

			using (var realDb = new RealBooksContexto())
			{
				var editoraArmazenada = realDb.Editoras.FirstOrDefault(e => e.EditoraId == editora.EditoraId);

				if (editoraArmazenada != null)
				{
					editoraArmazenada.Nome = editora.Nome;
					editoraArmazenada.Email = editora.Email;
				}

				realDb.SaveChanges();
			}
		}

		public void ExluirEditora(int id)
		{

			using (var realDb = new RealBooksContexto())
			{
				var editoraArmazenada = realDb.Editoras.Where(e => e.EditoraId == id).FirstOrDefault();

				realDb.Editoras.Remove(editoraArmazenada);

				realDb.SaveChanges();
			}
		}

		public Editora ObterEditora(int id) {
			using (var realDb = new RealBooksContexto())
			{
				return realDb.Editoras.Where(e => e.EditoraId == id).FirstOrDefault();
			}
		}
	}
}
