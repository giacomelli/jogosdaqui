using System;
using System.Diagnostics;
using Skahal.Infrastructure.Framework.Domain;

namespace jogosdaqui.Domain
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
		public Type EntityType { get; set; }
		#endregion
	}
}

