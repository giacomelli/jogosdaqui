using System;
using NUnit.Framework;
using Skahal.Infrastructure.Framework.Domain;
using TestSharp;
using jogosdaqui.Domain.Articles;
using jogosdaqui.Domain.Games;
using jogosdaqui.Domain.Tags;
using jogosdaqui.Domain.UnitTests;
using KissSpecifications;

namespace jogosdaqui.Domain.UnitTests
{
	public partial class AppliedTagServiceTest
	{	
		#region Tests
		[Test]
		public void GetAppliedTags_NullOrEmptyEntityName_Exception ()
		{
			var target = new AppliedTagService ();

			ExceptionAssert.IsThrowing(new ArgumentNullException("entityName"), () => {
				target.GetAppliedTags((string)null);
			});

			ExceptionAssert.IsThrowing(new ArgumentNullException("entityName"), () => {
				target.GetAppliedTags("");
			});
		}

		[Test]
		public void GetAppliedTags_EntityName_AppliedTags ()
		{
			var all = m_target.GetAllAppliedTags ();
			all [0].EntityName = "A";
			all [1].EntityName = "B";
			all [2].EntityName = "C";
			all [3].EntityName = "a";
			
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
		public void GetAppliedTags_NullEntity_Exception ()
		{
			var target = new AppliedTagService ();

			ExceptionAssert.IsThrowing(new ArgumentNullException("entity"), () => {
				target.GetAppliedTags((IEntity<long>)null);
			});
		}

		[Test]
		public void GetAppliedTags_Entity_AppliedTags ()
		{
			var all = m_target.GetAllAppliedTags ();
			all [0].EntityName = "Game";
			all [0].EntityKey = 1;

			all [1].EntityName = "Game";
			all [1].EntityKey = 1;

			all [2].EntityName = "News";
			all [2].EntityKey = 1;

			all [3].EntityName = "Game";
			all [3].EntityKey = 3;

			var actual = m_target.GetAppliedTags (new Game(1));
			Assert.AreEqual (2, actual.Count);

			actual = m_target.GetAppliedTags (new Game(3));
			Assert.AreEqual (1, actual.Count);

			actual = m_target.GetAppliedTags (new News(1));
			Assert.AreEqual (1, actual.Count);

			actual = m_target.GetAppliedTags (new Review(1));
			Assert.AreEqual (0, actual.Count);
		}

		[Test]
		public void GetAppliedTags_NullEntityNameAndKey_Exception ()
		{
			var target = new AppliedTagService ();

			ExceptionAssert.IsThrowing(new ArgumentNullException("entityName"), () => {
				target.GetAppliedTags(null, 1);
			});

			ExceptionAssert.IsThrowing(new ArgumentNullException("entityName"), () => {
				target.GetAppliedTags("", 1);
			});
		}

		[Test]
		public void GetAppliedTags_DoesNotExistsEntityWithName_Exception ()
		{
			var target = new AppliedTagService ();

			ExceptionAssert.IsThrowing(new ArgumentException ("There is no entity with the name 'Jogo'."), () => {
				target.GetAppliedTags("Jogo", 1);
			});
		}

		[Test]
		public void GetAppliedTags_EntityNameAndKey_AppliedTags ()
		{
			Stubs.GameRepository.Add (new Game(1));
			Stubs.GameRepository.Add (new Game(3));
			Stubs.NewsRepository.Add (new News(1));
			Stubs.ReviewRepository.Add (new Review(1));
			Stubs.UnitOfWork.Commit ();

			var all = m_target.GetAllAppliedTags ();
			all [0].EntityName = "Game";
			all [0].EntityKey = 1;

			all [1].EntityName = "Game";
			all [1].EntityKey = 1;

			all [2].EntityName = "News";
			all [2].EntityKey = 1;

			all [3].EntityName = "Game";
			all [3].EntityKey = 3;

			var actual = m_target.GetAppliedTags ("Game", 1);
			Assert.AreEqual (2, actual.Count);

			actual = m_target.GetAppliedTags ("Game", 3);
			Assert.AreEqual (1, actual.Count);

			actual = m_target.GetAppliedTags ("News", 1);
			Assert.AreEqual (1, actual.Count);

			actual = m_target.GetAppliedTags ("Review", 1);
			Assert.AreEqual (0, actual.Count);

			actual = m_target.GetAppliedTags ("Review", 2);
			Assert.AreEqual (0, actual.Count);
		}

		[Test]
		public void Save_EntityDoesNotExists_Exception()
		{
			var appliedTag = new AppliedTag ();
			appliedTag.EntityName = "Game";
			appliedTag.EntityKey = 0;

			var target = new AppliedTagService ();

			ExceptionAssert.IsThrowing(new SpecificationNotSatisfiedException("There is no Entity 'Game' with key '0'."), () => {
				target.SaveAppliedTag(appliedTag);
			});
		}

		[Test]
		public void SaveAppliedTag_AppliedTagDoesNotExists_Created()
		{
			Stubs.GameRepository.Add (new Game(1));
			Stubs.UnitOfWork.Commit ();

			var appliedtag = new AppliedTag ();
			appliedtag.EntityName = "Game";
			appliedtag.EntityKey = 1;

			m_target.SaveAppliedTag (appliedtag);

			Assert.AreEqual(5, m_target.CountAllAppliedTags());
			Assert.AreEqual (5, m_target.GetAppliedTagByKey (appliedtag.Key).Key);
		}

		[Test]
		public void SaveAppliedTag_AppliedTagDoesExists_Updated()
		{
			Stubs.GameRepository.Add (new Game(1));
			Stubs.UnitOfWork.Commit ();

			var appliedtag = new AppliedTag () { 
				Key = 1
			};

			appliedtag.EntityName = "Game";
			appliedtag.EntityKey = 1;

			m_target.SaveAppliedTag (appliedtag);

			Assert.AreEqual(4, m_target.CountAllAppliedTags());
			Assert.AreEqual (1, m_target.GetAppliedTagByKey (appliedtag.Key).Key);
		}
		#endregion
	}
}

