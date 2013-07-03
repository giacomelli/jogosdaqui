using System;
using Skahal.Infrastructure.Framework.Repositories;
using MongoDB.Driver;
using System.Configuration;
using Skahal.Infrastructure.Framework.Domain;
using MongoDB.Driver.Linq;
using System.Linq;
using System.Collections.Generic;

namespace jogosdaqui.Infrastructure.Repositories.MongoDB
{
	/// <summary>
	/// Mongo DB repository base class.
	/// </summary>
	public abstract class MongoDBRepositoryBase<TEntity>: RepositoryBase<TEntity, long>  
		where TEntity : IAggregateRoot<long>
	{
		#region Fields
		private MongoCollection<TEntity> m_collection;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="jogosdaqui.Infrastructure.Repositories.MongoDB.MongoDBRepositoryBase`1"/> class.
		/// </summary>
		public MongoDBRepositoryBase(string collectionName)
		{
			var connectionstring = ConfigurationManager.AppSettings.Get("MONGOLAB_URI");
			var url = new MongoUrl(connectionstring);
			var client = new MongoClient(url);
			var server = client.GetServer();
			var database = server.GetDatabase(String.IsNullOrWhiteSpace(url.DatabaseName) ? "test" : url.DatabaseName);
			m_collection = database.GetCollection<TEntity>(collectionName);
		}
		#endregion

		#region implemented abstract members of RepositoryBase

		/// <summary>
		/// Finds the entity by the key.
		/// </summary>
		/// <returns>The found entity.</returns>
		/// <param name="key">Key.</param>
		public override TEntity FindBy (long key)
		{
			return m_collection.AsQueryable<TEntity> ().FirstOrDefault(t => t.Key.Equals(key));
		}

		/// <summary>
		/// Finds all entities that matches the filter.
		/// </summary>
		/// <returns>The found entities.</returns>
		/// <param name="offset">Offset.</param>
		/// <param name="limit">Limit.</param>
		/// <param name="filter">Filter.</param>
		public override IEnumerable<TEntity> FindAll (int offset, int limit, Func<TEntity, bool> filter)
		{
			return m_collection.FindAll ().Where (filter).Skip (offset).Take (limit);
		}

		/// <summary>
		/// Counts all entities that matches the filter.
		/// </summary>
		/// <returns>The number of the entities that matches the filter.</returns>
		/// <param name="filter">Filter.</param>
		public override long CountAll (Func<TEntity, bool> filter)
		{
			return m_collection.FindAll ().LongCount (filter);
		}

		/// <summary>
		/// Persists the new item.
		/// </summary>
		/// <param name="item">Item.</param>
		protected override void PersistNewItem (TEntity item)
		{
			m_collection.Insert (item);
		}

		/// <summary>
		/// Persists the updated item.
		/// </summary>
		/// <param name="item">Item.</param>
		protected override void PersistUpdatedItem (TEntity item)
		{
			m_collection.Save (item);
		}

		/// <summary>
		/// Persists the deleted item.
		/// </summary>
		/// <param name="item">Item.</param>
		protected override void PersistDeletedItem (TEntity item)
		{
			m_collection.Remove(((MongoQueryable<TEntity>) m_collection.AsQueryable<TEntity>().Where(f => f.Key.Equals(item.Key))).GetMongoQuery());			
		}

		#endregion
	}
}