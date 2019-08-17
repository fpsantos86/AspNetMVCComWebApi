using Impacta.Tarefas.Core.Models;
using Impacta.Tarefas.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.Tarefas.Business
{
	public class EditoraBusiness
	{
		public List<Editora> ListarEditoras()
		{
			try
			{
				EditoraEF editoraEF = new EditoraEF();

				var ed = editoraEF.ListarEditoras();

				return ed;
			}
			catch (Exception ex)
			{
				throw new Exception("Falha ao tentar Validar a buscar das Editoras. Erro: \n" +
					ex.Message);
			}
		}

		public void CriarEditora(Editora editora) {
			EditoraEF editoraEF = new EditoraEF();
			editoraEF.CriarEditora(editora);

		}

		public void AlterarEditora(Editora editora)
		{
			EditoraEF editoraEF = new EditoraEF();
			editoraEF.AlterarEditora(editora);

		}

		public void ExcluirEditora(int id)
		{
			EditoraEF editoraEF = new EditoraEF();
			editoraEF.ExluirEditora(id);

		}

		public Editora ObterEditora(int id)
		{
			EditoraEF editoraEF = new EditoraEF();
			return editoraEF.ObterEditora(id);

		}
	}
}
