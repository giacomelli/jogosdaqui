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
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Tags.AppliedTag"/> class.
		/// </summary>
		public AppliedTag()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Tags.AppliedTag"/> class.
		/// </summary>
		/// <param name="key">Key.</param>
		public AppliedTag(long key) : base(key)
		{
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the tag key.
		/// </summary>
		/// <value>The tag key.</value>
		public long TagKey { get; set; }

		/// <summary>
		/// Gets or sets the entity key.
		/// </summary>
		/// <value>The entity key.</value>
		public long EntityKey { get; set; }

		/// <summary>
		/// Gets or sets the name of the entity.
		/// </summary>
		/// <value>The name of the entity.</value>
		public string EntityName { get; set; }

		/// <summary>
		/// Gets the entity.
		/// </summary>
		/// <value>The entity.</value>
		public IEntity<long> Entity
		{
			get {
				return ServiceFacade.GetEntity (EntityName, EntityKey);
			}
		}
		#endregion
	}
}