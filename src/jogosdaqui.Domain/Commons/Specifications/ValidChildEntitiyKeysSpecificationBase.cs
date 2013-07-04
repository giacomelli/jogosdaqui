using System;
using KissSpecifications;
using Skahal.Infrastructure.Framework.Domain;
using System.Collections.Generic;
using HelperSharp;
using System.Linq;
using System.Reflection;
using Skahal.Infrastructure.Framework.Globalization;

namespace jogosdaqui.Domain.Commons.Specifications
{
	/// <summary>
	/// Valid entities specification base.
	/// </summary>
	public abstract class ValidChildEntitiyKeysSpecificationBase<TEntity, TChildEntity> : SpecificationBase<TEntity> 
		where TEntity : IEntity<long>
		where TChildEntity : IEntity<long>
	{
		#region Fields
		private string m_parentEntityName;
		private string m_entityName;
		private string m_entityFriendlyName;
		private string m_entityFriendlyPluralName;
		#endregion

		#region Constructors
		protected ValidChildEntitiyKeysSpecificationBase(string entityFriendlyName, string entityFriendlyPluralName)
		{
			m_parentEntityName = typeof(TEntity).Name.Translate();
			m_entityName = typeof(TChildEntity).Name.Translate();
			m_entityFriendlyName = entityFriendlyName;
			m_entityFriendlyPluralName = entityFriendlyPluralName;
		}
		#endregion
	
		#region implemented abstract members of SpecificationBase
		/// <summary>
		/// Determines whether the target object satisfiy the specification.
		/// </summary>
		/// <param name="target">The target object to be validated.</param>
		/// <returns><c>true</c> if this instance is satisfied by the specified target; otherwise, <c>false</c>.</returns>
		public override bool IsSatisfiedBy (TEntity target)
		{
			var keysPropertyName = m_entityFriendlyName.Replace(" ", "") + "Keys";
			var targetType = target.GetType ();
			var keysProperty = targetType.GetProperty(keysPropertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

			if (keysProperty == null) {
				throw new InvalidOperationException("Property '{0}' not found on type '{1}'.".With(keysPropertyName, targetType.Name)); 
			}

			var keys = (IList<long>) keysProperty.GetValue (target);
			var firstDuplicatedKey = keys.GroupBy (k => k).Where (g => g.Count() > 1).Select (s => s.Key).FirstOrDefault ();

			if (firstDuplicatedKey != 0) {
				NotSatisfiedReason = "A {0} can't have duplicate {1}. The {2} with key '{3}' appears more than one time."
					.With (m_parentEntityName, m_entityFriendlyPluralName, m_entityFriendlyName, firstDuplicatedKey);

				return false;
			}

			foreach (var key in keys) {
				if (ServiceFacade.GetEntity(m_entityName, key) == null) {
					NotSatisfiedReason = "A {0} should have a valid {1}. The {1} with key '{2}' does not exists."
						.With (m_parentEntityName, m_entityFriendlyName, key);

					return false;
				}		
			}

			return true;
		}

		#endregion
	}
}