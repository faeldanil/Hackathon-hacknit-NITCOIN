using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ScoreClass.Web.Models.Incentivos
{
	public class Parceria
	{
		[Key]
		public Int64 Id { get; set; }
		public virtual List<Fidelidade> Programas { get; set; } = new List<Fidelidade>();
	}
}