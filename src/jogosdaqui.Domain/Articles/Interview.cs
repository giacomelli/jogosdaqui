using System;
using System.Collections.Generic;
using jogosdaqui.Domain.Persons;

namespace jogosdaqui.Domain.Articles
{
	public class Interview : ArticleBase
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Articles.Interview"/> class.
		/// </summary>
		public Interview()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Articles.Interview"/> class.
		/// </summary>
		/// <param name="key">Key.</param>
		public Interview(long key) : base(key)
		{
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the interviewed persons.
		/// </summary>
		/// <value>The interviewed persons.</value>
		public IList<Person> InterviewedPersons { get; private set; }
		#endregion
	}
}

