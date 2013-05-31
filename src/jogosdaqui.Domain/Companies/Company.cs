using System;

namespace jogosdaqui.Domain
{
	public abstract class Company
	{
		#region Properties
		public string Name { get; set; }
		#endregion

		#region Methods
		public bool IsDeveloper()
		{
			throw new NotImplementedException();
		}

		public bool IsPublisher()
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}

