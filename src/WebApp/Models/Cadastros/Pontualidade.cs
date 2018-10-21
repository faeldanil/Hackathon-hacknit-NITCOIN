using System;

namespace ScoreClass.Web.Models.Cadastros
{
	public class Pontualidade : Entidade
	{
        public DateTime DataHoraEntrada { get; set; }
        public DateTime DataHoraSaida { get; set; }
        public Matricula Matricula { get; set; }
    }
}