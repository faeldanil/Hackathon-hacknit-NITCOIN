﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ScoreClass.Web.Models
{
	public class Entidade
	{
		[Key, Display(Name = "Id")]
		public Int64 Id { get; set; }
	}
}
