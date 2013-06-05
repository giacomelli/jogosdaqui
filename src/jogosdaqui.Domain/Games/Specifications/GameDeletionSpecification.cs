using System;
using KissSpecifications;

namespace jogosdaqui.Domain.Games.Specifications
{
	public class GameDeletionSpecification : SpecificationBase<Game>
	{
		#region implemented abstract members of SpecificationBase
		/// <summary>
		/// Determines whether the target object satisfiy the specification.
		/// </summary>
		/// <param name="target">The target object to be validated.</param>
		/// <returns><c>true</c> if this instance is satisfied by the specified target; otherwise, <c>false</c>.</returns>
		public override bool IsSatisfiedBy (Game target)
		{
			if (target == null) {
				NotSatisfiedReason = "The game should exists to be deleted.";
				return false;
			}

			return true;
		}

		#endregion
	}
}