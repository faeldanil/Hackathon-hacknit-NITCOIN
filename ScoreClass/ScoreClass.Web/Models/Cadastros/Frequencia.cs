using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreClass.Web.Models.Cadastros
{
    public class Frequencia
    {
        [Key]
        public long Id { get; set; }
        public bool Compareceu { get; set; }
        public DateTime DataHora { get; set; }
        public Materia Materia { get; set; }
    }
}
