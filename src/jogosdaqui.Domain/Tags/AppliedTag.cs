using System;
using System.Diagnostics;
using Skahal.Infrastructure.Framework.Domain;

namespace jogosdaqui.Domain.Tags
{
	/// <summary>
	/// Represents an tag applied to an entity.
	/// </summary>
	[DebuggerDisplay("{Key}: {Name}")]
	public class AppliedTag : EntityBase<long>, IAggregateRoot<long>
	{
		#region Properties
		public long TagKey { get; set; }
		public long EntityKey { get; set; }
		public string EntityName { get; set; }

		public IEntity<long> Entity
		{
			get {
				return ServiceFacade.GetEntity (EntityName, EntityKey);
			}
		}
		#endregion
	}
}