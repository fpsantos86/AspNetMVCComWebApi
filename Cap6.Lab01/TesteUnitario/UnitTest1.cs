using System;
using Impacta.Tarefas.Core.Models;
using Impacta.Tarefas.DAL;
using Impacta.Tarefas.EF;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TesteUnitario
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			Data data = new Data();

			
		}


		[TestMethod]
		public void Teste_EF()
		{
			RealBooksContexto contexto = new RealBooksContexto();

			Editora editora = new Editora();
			editora.Nome = "Teste";

			contexto.Editoras.Add(editora);

			contexto.SaveChanges();
		}
	}
}
