using System;
using Skahal.Infrastructure.Framework.Domain;
using System.Diagnostics;

namespace jogosdaqui.Domain.Languages
{
	[DebuggerDisplay("{Key}: {Name} | {Code}")]
	public class Language : EntityBase<long>, IAggregateRoot<long>
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Languages.Language"/> class.
		/// </summary>
		public Language()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Languages.Language"/> class.
		/// </summary>
		/// <param name="key">Key.</param>
		public Language(long key) : base(key)
		{
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the code.
		/// </summary>
		/// <value>The code.</value>
		public string Code { get; set; }
		#endregion
	}
}

