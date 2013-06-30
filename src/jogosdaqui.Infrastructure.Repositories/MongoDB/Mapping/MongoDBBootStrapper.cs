using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDBIntIdGenerator;
using Skahal.Infrastructure.Framework.Domain;
using jogosdaqui.Domain.Tags;

namespace jogosdaqui.Infrastructure.Repositories
{
	public static class MongoDBBootStrapper
	{
		public static void Start ()
		{
			var convention = new ConventionPack ();
			convention.Add(new CamelCaseElementNameConvention());
		
			BsonClassMap.RegisterClassMap<EntityBase<long>>(cm => {
				cm.MapIdMember(e => e.Key).SetIdGenerator(new IntIdGenerator());
			});
		}
	}
}

