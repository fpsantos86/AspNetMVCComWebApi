using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Impacta.Tarefas.Core.Models;


namespace Impacta.Tarefas.ClientAPI
{
	public class Program
	{
		static void Main(string[] args)
		{
			RunAsync().Wait();
		}

		static async Task RunAsync()
		{
			var formato = new MediaTypeWithQualityHeaderValue("application/json");

			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("http://localhost:52431/");
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(formato);

				var resposta = await client.GetAsync("api/WebApiEditora");

				var conteudo = await resposta.Content.ReadAsAsync<IEnumerable<Editora>>();

				foreach (var item in conteudo)
				{
					Console.WriteLine($"EditoraID: {item.EditoraId}\nNome: {item.Nome }\nEmail: {item.Email}"	);
				}
			}
			Console.ReadLine();
		}
	}
}

