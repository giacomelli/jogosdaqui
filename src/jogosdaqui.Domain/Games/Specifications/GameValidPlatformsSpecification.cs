using System;
using KissSpecifications;
using jogosdaqui.Domain.Platforms;
using HelperSharp;
using System.Linq;

namespace jogosdaqui.Domain.Games.Specifications
{
	/// <summary>
	/// Game valid platforms specification.
	/// </summary>
	public class GameValidPlatformsSpecification : SpecificationBase<Game>
	{
		#region implemented abstract members of SpecificationBase
		/// <summary>
		/// Determines whether the target object satisfiy the specification.
		/// </summary>
		/// <param name="target">The target object to be validated.</param>
		/// <returns><c>true</c> if this instance is satisfied by the specified target; otherwise, <c>false</c>.</returns>
		public override bool IsSatisfiedBy (Game target)
		{
			var keys = target.PlatformKeys;

			if (keys.Count == 0) {
				NotSatisfiedReason = "A game should have at least one platform.";
				return false;
			}

			var firstDuplicatedKey = keys.GroupBy (k => k).Where (g => g.Count() > 1).Select (s => s.Key).FirstOrDefault ();

			if (firstDuplicatedKey != 0) {
				NotSatisfiedReason = "Game can't have duplicate platforms. The platform with key '{0}' appears more than one time.".With (firstDuplicatedKey);
				return false;
			}

			var platformService = new PlatformService ();

			foreach (var key in keys) {
				if (platformService.GetPlatformByKey (key) == null) {
					NotSatisfiedReason = "Game should have a valid platform. The platform with key '{0}' does not exists.".With (key);
					return false;
				}		
			}

			return true;
		}

		#endregion
	}
}