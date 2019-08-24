using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impacta.Tarefas.Core.Models
{
	public class Editora
	{
		[Display(Name = "CÓDIGO DA EDITORA")]
		public int EditoraId { get; set; }

		[Display(Name = "RAZÃO SOCIAL")]
		[Required(ErrorMessage = "Razão social deve ser informada")]
		public string Nome { get; set; }

		[EmailAddress] // Se formato não for de email emitira uma mensagem
		[Required(ErrorMessage = "E-mail de contato não esta sendo informado")]
		public string Email { get; set; }

		[Required]
		public string Cnpj { get; set; }

		[Phone]
		public string Telefone { get; set; }

		public Endereco Endereco { get; set; }

		public string Url { get; set; }

		public override string ToString()
		{
			return $"{this.EditoraId} \n {this.Nome } \n {this.Email}";	
		}
	}

}
