﻿using System;

namespace ScoreClass.Web.Models.Cadastros
{
	public class Ocorrencia : Entidade
	{
		public Materia Materia { get; set; }
		public DateTime DataHora { get; set; }
        public string Descricao { get; set; }
        public StatusAvaliacao TipoComportamento { get; set; }
    }
}