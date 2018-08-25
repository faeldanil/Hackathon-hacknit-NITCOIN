using System;
using System.Collections.Generic;

namespace ScoreClass.Web.Models.Incentivos
{
	public class Parceria
	{
		public Int64 Id { get; set; }
		public List<Fidelidade> Programas { get; set; }
	}
}