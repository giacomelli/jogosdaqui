using System;
using KissSpecifications;
using HelperSharp;

namespace jogosdaqui.Domain.Tags.Specifications
{
	/// <summary>
	/// Applied tag save specification.
	/// </summary>
	public class AppliedTagSaveSpecification : SpecificationBase<AppliedTag>
	{
		/// <summary>
		/// Determines whether the target object satisfiy the specification.
		/// </summary>
		/// <param name="target">The target object to be validated.</param>
		/// <returns><c>true</c> if this instance is satisfied by the specified target; otherwise, <c>false</c>.</returns>
		public override bool IsSatisfiedBy (AppliedTag target)
		{
			var entityToApplyTag = ServiceFacade.GetEntity (target.EntityName, target.EntityKey);

			if (entityToApplyTag == null) {
				NotSatisfiedReason = 
					"There is no Entity '{0}' with key '{1}'."
				    .With(target.EntityName, target.EntityKey);

				return false;
			}

			return true;
		}
	}
}