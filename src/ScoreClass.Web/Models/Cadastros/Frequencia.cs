using System;

namespace ScoreClass.Web.Models.Cadastros
{
	public class Frequencia : Entidade
	{
        public bool Compareceu { get; set; }
        public DateTime DataHora { get; set; }
        public Materia Materia { get; set; }
        public string Bimestre { get; set; }
    }
}