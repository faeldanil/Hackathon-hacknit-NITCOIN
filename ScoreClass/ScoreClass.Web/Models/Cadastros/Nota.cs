namespace ScoreClass.Web.Models.Cadastros
{
	public class Nota : Entidade
	{
		public string Descricao { get; set; }
		public string Bimestre { get; set; }
		public Materia Materia { get; set; }
	}
}