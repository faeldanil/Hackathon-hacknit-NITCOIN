using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreClass.Web.Models.Cadastros
{
    public class Ocorrencia
    {
        [Key]
        public long Id { get; set; }
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }
        public StatusAvaliacao TipoComportamento { get; set; }
    }
}
