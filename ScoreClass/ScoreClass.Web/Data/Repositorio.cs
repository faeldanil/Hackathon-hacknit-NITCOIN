using ScoreClass.Web.Models;
using System;
using System.Collections.Generic;

namespace ScoreClass.Web.Data
{
	public partial class Repositorio
	{
		public static readonly Repositorio Ativo = new Repositorio();

		private readonly Dictionary<Type, Object> _caches = new Dictionary<Type, Object>();

		public IEnumerable<TEntidade> Obter<TEntidade>() where TEntidade : Entidade
		{
			var cache = ObterCache<TEntidade>();
			return cache.Obter();
		}

		public void Add<TEntidade>(TEntidade entidade) where TEntidade : Entidade
		{
			var cache = ObterCache<TEntidade>();
			cache.Incluir(entidade);
		}

		public void Remove<TEntidade>(TEntidade entidade) where TEntidade : Entidade
		{
			var cache = ObterCache<TEntidade>();
			cache.Excluir(entidade);
		}

		internal void RemoveAll<TEntidade>() where TEntidade : Entidade
		{
			var cache = ObterCache<TEntidade>();
			cache.ExcluirTodos();
		}

		public void Update<TEntidade>(TEntidade entidade) where TEntidade : Entidade
		{
			var cache = ObterCache<TEntidade>();
			cache.Alterar(entidade);
		}

		private Repositorio<TEntidade> ObterCache<TEntidade>() where TEntidade : Entidade
		{
			var type = typeof(TEntidade);
			if (!_caches.TryGetValue(type, out var cache))
				cache = _caches[type] = new Repositorio<TEntidade>();
			return ((Repositorio<TEntidade>)cache);
		}
	}


	public class Repositorio<TEntidade> where TEntidade : Entidade
	{
		private readonly List<TEntidade> _cache = new List<TEntidade>();

		public IEnumerable<TEntidade> Obter()
		{
			return _cache;
		}

		internal void Incluir(TEntidade entidade)
		{
			_cache.Add(entidade);
		}

		internal void Alterar(TEntidade entidade)
		{
			Excluir(entidade);
			Incluir(entidade);
		}

		internal void Excluir(TEntidade entidade)
		{
			_cache.RemoveAll(d => d.Id == entidade.Id);
		}

		internal void ExcluirTodos()
		{
			_cache.Clear();
		}

	}
}