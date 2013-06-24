using System;
using KissSpecifications;
using HelperSharp;

namespace jogosdaqui.Domain.Articles.Specifications
{
	/// <summary>
	/// Article exists specification.
	/// </summary>
	public class ArticleExistsSpecification : SpecificationBase<ArticleBase>
	{
		#region Fields
		private long m_articleKey;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="jogosdaqui.Domain.Articles.Specifications.ArticleExistsSpecification"/> class.
		/// </summary>
		/// <param name="gameKey">Game key.</param>
		public ArticleExistsSpecification(long articleKey)
		{
			m_articleKey = articleKey;
		}
		#endregion

		#region implemented abstract members of SpecificationBase
		/// <summary>
		/// Determines whether the target object satisfiy the specification.
		/// </summary>
		/// <param name="target">The target object to be validated.</param>
		/// <returns><c>true</c> if this instance is satisfied by the specified target; otherwise, <c>false</c>.</returns>
		public override bool IsSatisfiedBy (ArticleBase target)
		{
			if(target == null)
			{
				NotSatisfiedReason = "Article with key '{0}' does not exists.".With (m_articleKey);
				return false;
			}

			return true;
		}

		#endregion
	}
}