using System;
using System.Collections.Generic;
using jogosdaqui.Domain.Persons;

namespace jogosdaqui.Domain.Articles
{
	public class Interview : ArticleBase
	{
		#region Properties
		public IList<Person> InterviewedPersons { get; private set; }
		#endregion
	}
}

