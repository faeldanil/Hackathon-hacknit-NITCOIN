using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreClass.Web.Models.Cadastros
{
    public class Responsavel
    {
        [Key]
        public long Id { get; set; }
        public string Nome { get; set; }
        public Email Email { get; set; }
        public string Telefone { get; set; }
    }
}
