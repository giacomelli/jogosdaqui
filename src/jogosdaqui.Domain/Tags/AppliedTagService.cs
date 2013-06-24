using System;
using System.Collections.Generic;
using System.Linq;
using HelperSharp;
using Skahal.Infrastructure.Framework.Domain;
using Skahal.Infrastructure.Framework.Repositories;
using KissSpecifications;
using jogosdaqui.Domain.Tags.Specifications;

namespace jogosdaqui.Domain.Tags
{
	public partial class AppliedTagService
	{
		#region Methods
		/// <summary>
		/// Executes the save specification.
		/// </summary>
		/// <param name="appliedtag">Appliedtag.</param>
		partial void ExecuteSaveSpecification (AppliedTag appliedtag)
		{
			SpecificationService.ThrowIfAnySpecificationIsNotSatisfiedBy(
				appliedtag,
				new AppliedTagSaveSpecification());
		}

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

			return MainRepository
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

			return MainRepository
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
			IList<AppliedTag> result;
			var entity = ServiceFacade.GetEntity (entityName, entityKey);

			if (entity == null) {
				result = new List<AppliedTag> ();
			} else {
				result = GetAppliedTags (entity);
			}

			return result;
		}
		#endregion
	}
}