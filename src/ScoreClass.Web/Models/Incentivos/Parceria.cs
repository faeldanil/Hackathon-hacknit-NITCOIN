using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ScoreClass.Web.Models.Incentivos
{
	public class Parceria : Entidade
	{
		public virtual List<Fidelidade> Programas { get; set; } = new List<Fidelidade>();
		public string Nome { get; internal set; }
	}
}