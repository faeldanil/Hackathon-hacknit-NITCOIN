using System.ComponentModel.DataAnnotations;

namespace ScoreClass.Web.Models.Cadastros
{
    public class Email
    {
        [Key]
        public string Descricao { get; set; }
    }
}