using System;
using KissSpecifications;
using jogosdaqui.Domain.Platforms;
using HelperSharp;
using System.Linq;
using jogosdaqui.Domain.Commons.Specifications;

namespace jogosdaqui.Domain.Games.Specifications
{
	/// <summary>
	/// Game valid platforms specification.
	/// </summary>
	public class GameValidPlatformsSpecification : ValidChildEntitiyKeysSpecificationBase<Game, Platform>
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="jogosdaqui.Domain.Games.Specifications.GameValidPlatformsSpecification"/> class.
		/// </summary>
		public GameValidPlatformsSpecification() : base("platform", "platforms")
		{
		}
		#endregion
	

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

			if(!base.IsSatisfiedBy(target))
			{
				return false;
			}

			return true;
		}

		#endregion
	}
}