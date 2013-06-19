using System;
using NUnit.Framework;
using TestSharp;
using jogosdaqui.Domain.Tags;

namespace jogosdaqui.Domain.UnitTests.Tags
{
	[TestFixture()]
	public class AppliedTagServiceTest
	{
		#region Fields
		private AppliedTagService m_target;
		#endregion

		#region Initialize
		[SetUp]
		public void InitializeTest()
		{
			Stubs.Initialize ();
			Stubs.AppliedTagRepository.Add (new AppliedTag() { EntityName = "A" });
			Stubs.AppliedTagRepository.Add (new AppliedTag() { EntityName = "B" });
			Stubs.AppliedTagRepository.Add (new AppliedTag() { EntityName = "C" });
			Stubs.AppliedTagRepository.Add (new AppliedTag() { EntityName = "A" });
			Stubs.UnitOfWork.Commit ();

			m_target = new AppliedTagService ();

		}
		#endregion

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
		public void CountAllAppliedTags_NoArguments_AllAppliedTagsCounted()
		{
			var actual = m_target.CountAllAppliedTags ();
			Assert.AreEqual (4, actual);
		}

//		[Test]
//		public void DeleteAppliedTag_AppliedTagNotExistis_Exception()
//		{
//			ExceptionAssert.IsThrowing (new ArgumentException("AppliedTag with key '0' does not exists."), () => {
//				m_target.DeleteAppliedTag(0);
//			});
//		}
		#endregion
	}
}

