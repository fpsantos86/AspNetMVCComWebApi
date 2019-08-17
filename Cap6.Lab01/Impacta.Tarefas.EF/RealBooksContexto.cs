using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Impacta.Tarefas.Core.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Impacta.Tarefas.EF
{
	public class RealBooksContexto : DbContext
	{
		public RealBooksContexto(): base("RealBooksContext")
		{

		}

		public DbSet<Editora> Editoras { get; set; }
		public DbSet<Livro> Livros { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}

	}
}
