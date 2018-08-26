using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreClass.Web.Data.Migrations
{
	public class Repositorio
	{
		public static readonly Repositorio Ativo = new Repositorio();

		private readonly Dictionary<Type, Object> _caches = new Dictionary<Type, Object>();

		public IEnumerable<TEntidade> Obter<TEntidade>(Func<IEnumerable<TEntidade>> funcao) where TEntidade : Entidade
		{
			var cache = ObterCache<TEntidade>();
			return cache.Obter(funcao);
		}

		public void Incluir<TEntidade>(TEntidade entidade) where TEntidade : Entidade
		{
			var cache = ObterCache<TEntidade>();
			cache.Incluir(entidade);
		}

		public void Excluir<TEntidade>(TEntidade entidade) where TEntidade : Entidade
		{
			var cache = ObterCache<TEntidade>();
			cache.Excluir(entidade);
		}

		public void Alterar<TEntidade>(TEntidade entidade) where TEntidade : Entidade
		{
			var cache = ObterCache<TEntidade>();
			cache.Alterar(entidade);
		}

		private Cache<TEntidade> ObterCache<TEntidade>() where TEntidade : Entidade
		{
			var type = typeof(TEntidade);
			if (!_caches.TryGetValue(type, out var cache))
				cache = _caches[type] = new Cache<TEntidade>(_timeOut);
			return ((Cache<TEntidade>)cache);
		}
	}


	public class Cache<TEntidade> where TEntidade : Entidade
	{
		private readonly TimeSpan _timeOut;
		private readonly List<TEntidade> _cache = new List<TEntidade>();

		private DateTime ultimaRenovacao = DateTime.Now;

		public Cache(TimeSpan timeOut)
		{
			_timeOut = timeOut;
		}

		private Boolean EhValido { get => ultimaRenovacao.Add(_timeOut) > DateTime.Now; }

		public IEnumerable<TEntidade> Obter(Func<IEnumerable<TEntidade>> funcao)
		{
			return _cache.Any() && EhValido ? _cache : ColocarEmCache(funcao());
		}

		private IEnumerable<TEntidade> ColocarEmCache(IEnumerable<TEntidade> dados)
		{
			ultimaRenovacao = DateTime.Now;
			_cache.Clear();
			_cache.AddRange(dados);
			return dados;
		}

		public void Incluir(TEntidade entidade)
		{
			_cache.Add(entidade);
		}

		public void Alterar(TEntidade entidade)
		{
			Excluir(entidade);
			Incluir(entidade);
		}

		internal void Excluir(TEntidade entidade)
		{
			_cache.RemoveAll(d => d.Id == entidade.Id);
		}
	}
}
