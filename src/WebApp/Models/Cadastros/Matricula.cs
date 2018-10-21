using System;
using System.Collections.Generic;

namespace ScoreClass.Web.Models.Cadastros
{
	public class Matricula : Entidade
	{
        public string Codigo { get; set; }
		public Int32 AnoLetivo { get; set; }
		public virtual Aluno Aluno { get; set; }
		public virtual Turma Turma { get; set; }
		public virtual List<Pontualidade> Pontualidades { get; set; } = new List<Pontualidade>();
		public virtual List<Materia> Materias { get; set; } = new List<Materia>();

        string[] _alfabeto = { "A", "B", "C", "D", "D", "F", "G", "H" };

        private Random _valorAleatorio = new Random();

        public string GerarCodigo
        {
            get
            {
                var pos1 = _valorAleatorio.Next(0, _alfabeto.Length);
                var pos2 = _valorAleatorio.Next(0, _alfabeto.Length);
                var pos3 = _valorAleatorio.Next(0, _alfabeto.Length);
                
                var numero = _valorAleatorio.Next(10000, 20000);

                return _alfabeto[pos1] + _alfabeto[pos2] + _alfabeto[pos3] + numero.ToString();
            }
        }
    }
}
