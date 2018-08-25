using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreClass.Web.Models.Cadastros
{
    public class Matricula
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual IEnumerable<Pontualidade> Pontualidades { get; set; }
        public virtual IEnumerable<Materia> Materias { get; set; }

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
