using System;
using System.Collections.Generic;

namespace jogosdaqui.Domain
{
	public class GameEvaluation
	{
		#region Properties
		public int GameId { get; set; }
		public string GameVersion { get; set; }
		public IList<string> Pros { get; private set; }
		public IList<string> Cons { get; private set; }
		#endregion
	}
}