using System;
using KissSpecifications;

namespace jogosdaqui.Domain.Evaluations.Specifications
{
	/// <summary>
	/// Evaluation has valid pros and cons specification.
	/// </summary>
	public class EvaluationValidProsAndConsSpecification : SpecificationBase<Evaluation>
	{
		#region implemented abstract members of SpecificationBase
		/// <summary>
		/// Determines whether the target object satisfiy the specification.
		/// </summary>
		/// <param name="target">The target object to be validated.</param>
		/// <returns><c>true</c> if this instance is satisfied by the specified target; otherwise, <c>false</c>.</returns>
		public override bool IsSatisfiedBy (Evaluation target)
		{
			if (target.Cons.Count == 0) {
				NotSatisfiedReason = "An evaluation should have at least one con.";
				return false;
			}

			if (target.Pros.Count == 0) {
				NotSatisfiedReason = "An evaluation should have at least one pro.";
				return false;
			}

			return true;
		}

		#endregion
	}
}