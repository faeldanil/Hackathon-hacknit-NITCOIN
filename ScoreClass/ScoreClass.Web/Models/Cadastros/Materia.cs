using System;
using System.Collections.Generic;
using System.Linq;

namespace ScoreClass.Web.Models.Cadastros
{
    public class Materia : Entidade
    {
        public string Nome { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual List<Nota> Notas { get; set; } = new List<Nota>();
        public Disciplina Disciplina { get; set; }
        public virtual List<Frequencia> Frequencias { get; set; } = new List<Frequencia>();
        public virtual List<Ocorrencia> Ocorrencias { get; set; } = new List<Ocorrencia>();


        public string ObterFrequencias(string bimestre)
        {
            var total = Frequencias.Where(x => x.Bimestre == bimestre).Count().ToString();
            var parcial = Frequencias.Where(x => x.Bimestre == bimestre).Count(x => x.Compareceu).ToString();
            return parcial + " / " + total;
        }

        public List<string> ObterOcorrencias
        {
            get
            {
                var lista = new List<string>();
                foreach (var item in Ocorrencias.Where(x => x.DataHora.Year == DateTime.Today.Year))
                {
                    lista.Add(item.Descricao);
                }

                return lista;
            }
        }
    }
}