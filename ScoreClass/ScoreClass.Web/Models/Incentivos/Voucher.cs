﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ScoreClass.Web.Models.Incentivos
{
	public class Voucher
	{
		[Key]
		public Int64 Id { get; set; }
		public virtual NitCoin NitCoinOrigem { get; set; }
		public virtual Fidelidade Fidelidade { get; set; }
		public Int32 Quantidade { get; set; }
		public Int32 Valor { get; set; }
		public String Codigo { get; set; }
		public DateTime Validade { get; set; }
		public Boolean Resgatado { get; set; }
	}
}