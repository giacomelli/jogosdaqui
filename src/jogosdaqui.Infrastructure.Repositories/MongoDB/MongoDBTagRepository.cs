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
	public class MongoDBTagRepository : MongoDBRepositoryBase<Tag>,  ITagRepository
	{

	}
}