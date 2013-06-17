using System;
using Skahal.Infrastructure.Framework.Domain;
using System.Diagnostics;

namespace jogosdaqui.Domain.Languages
{
	[DebuggerDisplay("{Key}: {Name} | {Code}")]
	public class Language : EntityBase<long>, IAggregateRoot<long>
	{
		#region Properties
		public string Name { get; set; }
		public string Code { get; set; }
		#endregion
	}
}

