using System;
using KissSpecifications;
using jogosdaqui.Domain.Games;
using HelperSharp;

namespace jogosdaqui.Domain.Evaluations.Specifications
{
	/// <summary>
	/// Evaluation has game specification.
	/// </summary>
	public class EvaluationValidGameSpecification : SpecificationBase<Evaluation>
	{
		#region implemented abstract members of SpecificationBase
		/// <summary>
		/// Determines whether the target object satisfiy the specification.
		/// </summary>
		/// <param name="target">The target object to be validated.</param>
		/// <returns><c>true</c> if this instance is satisfied by the specified target; otherwise, <c>false</c>.</returns>
		public override bool IsSatisfiedBy (Evaluation target)
		{
			var game = new GameService ().GetGameByKey (target.GameKey);
		
			if (game == null) {
				NotSatisfiedReason = "Evaluation should have a valid Game. The game with key '{0}' does not exists.".With(target.GameKey);
				return false;
			}
		
			return true;
		}

		#endregion


	}
}

