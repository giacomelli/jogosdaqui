using System;
using NUnit.Framework;
using TestSharp;
using jogosdaqui.Domain.Tags;

namespace jogosdaqui.Domain.Tags.UnitTests
{
	[TestFixture()]
	public partial class AppliedTagServiceTest
	{	
		#region Tests

		[Test]
		public void GetAppliedTags_NullOrEmptyEntityName_Exception ()
		{
			var target = new AppliedTagService ();

			ExceptionAssert.IsThrowing(new ArgumentNullException("entityName"), () => {
				target.GetAppliedTags(null);
			});

			ExceptionAssert.IsThrowing(new ArgumentNullException("entityName"), () => {
				target.GetAppliedTags("");
			});
		}

		[Test]
		public void GetAppliedTags_EntityName_AppliedTags ()
		{
			var actual = m_target.GetAppliedTags ("A");
			Assert.AreEqual (2, actual.Count);

			actual = m_target.GetAppliedTags ("a");
			Assert.AreEqual (2, actual.Count);

			actual = m_target.GetAppliedTags ("B");
			Assert.AreEqual (1, actual.Count);

			actual = m_target.GetAppliedTags ("C");
			Assert.AreEqual (1, actual.Count);

			actual = m_target.GetAppliedTags ("D");
			Assert.AreEqual (0, actual.Count);
		}
	
		[Test]
		public void SaveAppliedTag_Null_Exception ()
		{
			ExceptionAssert.IsThrowing (new ArgumentNullException("appliedTag"), () => {
				m_target.SaveAppliedTag (null);
			});
		}

		[Test]
		public void SaveAppliedTag_AppliedTagDoesNotExists_Created()
		{
			var appliedTag = new AppliedTag () { 
				TagKey = 1,
				EntityKey = 1,
				EntityName = "Game"
			};

			m_target.SaveAppliedTag (appliedTag);

			Assert.AreEqual(5, m_target.CountAllAppliedTags());
			Assert.AreEqual ("Game", m_target.GetAppliedTagByKey (appliedTag.Key).EntityName);
		}

		[Test]
		public void SaveAppliedTag_AppliedTagDoesExists_Updated()
		{
			var appliedTag = new AppliedTag () { 
				Key = 1,
				TagKey = 1,
				EntityKey = 1,
				EntityName = "Game"
			};

			m_target.SaveAppliedTag (appliedTag);

			Assert.AreEqual(4, m_target.CountAllAppliedTags());
			Assert.AreEqual ("Game", m_target.GetAppliedTagByKey (appliedTag.Key).EntityName);
		}
		#endregion
	}
}

