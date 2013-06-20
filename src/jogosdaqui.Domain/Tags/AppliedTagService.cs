using System;
using System.Collections.Generic;
using Skahal.Infrastructure.Framework.Repositories;
using System.Linq;
using Skahal.Infrastructure.Framework.Domain;
using HelperSharp;

namespace jogosdaqui.Domain.Tags
{
	public partial class AppliedTagService
	{
		/// <summary>
		/// Gets the applied tags for the entity name specified.
		/// </summary>
		/// <returns>The applied tags.</returns>
		/// <param name="entityName">Entity name.</param>
		public IList<AppliedTag> GetAppliedTags(string entityName)
		{
			if(String.IsNullOrWhiteSpace(entityName))
			{
				throw new ArgumentNullException ("entityName");
			}

			return m_repository
					.FindAll ((a) => a.EntityName.Equals(entityName, StringComparison.OrdinalIgnoreCase))
					.ToList ();
		}

		/// <summary>
		/// Gets the applied tags for the entity specify.
		/// </summary>
		/// <returns>The applied tags.</returns>
		/// <param name="entity">Entity.</param>
		public IList<AppliedTag> GetAppliedTags(IEntity<long> entity)
		{
			ExceptionHelper.ThrowIfNull ("entity", entity);

			var entityName = entity.GetType ().Name;

			return m_repository
					.FindAll (
						(a) => 	a.EntityName.Equals(entityName, StringComparison.OrdinalIgnoreCase)
							&&	a.EntityKey.Equals(entity.Key))
					.ToList ();
		}

		/// <summary>
		/// Gets the applied tags for the entity name and key specified.
		/// </summary>
		/// <returns>The applied tags.</returns>
		/// <param name="entityName">Entity name.</param>
		/// <param name="entityKey">Entity key.</param>
		public IList<AppliedTag> GetAppliedTags(string entityName, long entityKey)
		{
			if(String.IsNullOrWhiteSpace(entityName))
			{
				throw new ArgumentNullException ("entityName");
			}

			var assembly = typeof(AppliedTagService).Assembly;
			var entityType = assembly.GetTypes ().FirstOrDefault (t => t.Name.Equals(entityName, StringComparison.OrdinalIgnoreCase));

			if (entityType == null) {
				throw new ArgumentException ("There is no entity with the name '{0}'.".With(entityName));
			}

			var entity = (IEntity<long>)assembly.CreateInstance (entityType.FullName);
			entity.Key = entityKey;

			return GetAppliedTags(entity);
		}
	}
}