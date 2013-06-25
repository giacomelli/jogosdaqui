using System;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Skahal.Infrastructure.Framework.Repositories;
using jogosdaqui.Domain.Tags;
using MongoDB.Driver.Builders;

namespace jogosdaqui.Infrastructure.Repositories.MongoDB
{
	public class MongoDBTagRepository : RepositoryBase<Tag, long>,  ITagRepository
	{
		#region Fields
		private MongoDatabase m_database;
		private MongoCollection<Tag> m_collection;
		#endregion

		#region Constructors
		public MongoDBTagRepository()
		{
			var connectionstring = ConfigurationManager.AppSettings.Get("MONGOLAB_URI");
			var url = new MongoUrl(connectionstring);
			var client = new MongoClient(url);
			var server = client.GetServer();
			m_database = server.GetDatabase(url.DatabaseName);

			m_collection = m_database.GetCollection<Tag>("Tags");
			//m_collection.RemoveAll ();
		}
		#endregion

		#region implemented abstract members of RepositoryBase

		public override Tag FindBy (long key)
		{
			return m_collection.AsQueryable<Tag> ().FirstOrDefault(t => t.Key.Equals(key));
		}

		public override IEnumerable<Tag> FindAll (int offset, int limit, Func<Tag, bool> filter)
		{
			var query = m_collection.AsQueryable<Tag> ().Where(t => true).Skip (offset).Take (limit);
		

			return query.ToList ();
		}

		public override long CountAll (Func<Tag, bool> filter)
		{
			return m_collection.Count ();
		}

		protected override void PersistNewItem (Tag item)
		{
			m_collection.Insert (item);
		}

		protected override void PersistUpdatedItem (Tag item)
		{
			m_collection.Save (item);
		}

		protected override void PersistDeletedItem (Tag item)
		{
			m_collection.Remove(((MongoQueryable<Tag>) m_collection.AsQueryable<Tag>().Where(f => f.Equals(item))).GetMongoQuery());			
		}

		#endregion


	}
}