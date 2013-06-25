using System;
using MongoDB.Bson.Serialization;
using jogosdaqui.Domain.Tags;
using MongoDB.Bson.Serialization.Conventions;
using Skahal.Infrastructure.Framework.Domain;
using MongoDBIntIdGenerator;
using MongoDB.Bson;

namespace jogosdaqui.Infrastructure.Repositories
{
	public static class MongoDBBootStrapper
	{
		public static void Start ()
		{
			var convention = new ConventionPack ();
			convention.Add(new CamelCaseElementNameConvention());
		//	convention.AddMemberMapConvention("Key", (m) => m.SetElementName("_id"));

			BsonClassMap.RegisterClassMap<EntityBase<long>>(cm => {
				cm.MapIdMember(e => e.Key).SetIdGenerator(new IntIdGenerator());
			});
		}
	}
}

