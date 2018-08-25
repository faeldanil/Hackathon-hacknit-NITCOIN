using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreClass.Web.Models.Cadastros
{
    public class Nota
    {
        [Key]
        public long Id { get; set; }
        public string Descricao { get; set; }
        public string Bimestre { get; set; }
        public Materia Materia { get; set; }
    }
}
