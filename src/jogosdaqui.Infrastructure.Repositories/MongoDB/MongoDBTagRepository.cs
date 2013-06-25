using System;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Skahal.Infrastructure.Framework.Repositories;
using jogosdaqui.Domain.Tags;

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
			var connectionstring = ConfigurationManager.AppSettings.Get("(MONGOHQ_URL|MONGOLAB_URI)");
			var url = new MongoUrl(connectionstring);
			var client = new MongoClient(url);
			var server = client.GetServer();
			m_database = server.GetDatabase(url.DatabaseName);

			m_collection = m_database.GetCollection<Tag>("Tags");
		}
		#endregion

		#region implemented abstract members of RepositoryBase

		public override Tag FindBy (long key)
		{
			throw new NotImplementedException ();
		}

		public override IEnumerable<Tag> FindAll (int offset, int limit, Func<Tag, bool> filter)
		{
			var query = (from t in m_collection.AsQueryable<Tag> () where filter (t) select t)
				.Skip (offset).Take (limit);
		

			return query.ToList ();
		}

		public override int CountAll (Func<Tag, bool> filter)
		{
			throw new NotImplementedException ();
		}

		protected override void PersistNewItem (Tag item)
		{
			m_collection.Insert (item);
		}

		protected override void PersistUpdatedItem (Tag item)
		{
			throw new NotImplementedException ();
		}

		protected override void PersistDeletedItem (Tag item)
		{
			throw new NotImplementedException ();
		}

		#endregion


	}
}