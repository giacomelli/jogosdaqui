using NUnit.Framework;
using System;
using jogosdaqui.Domain.Games;
using Rhino.Mocks;
using Skahal.Infrastructure.Framework.Commons;
using System.Linq;

namespace jogosdaqui.Domain.UnitTests
{
	[TestFixture()]
	public class GameServiceTest
	{
		#region Fields
		private IGameRepository m_repository;
		#endregion

		#region Initiliaze / cleanup
		[SetUp]
		public void InitializeTest()
		{
			m_repository = MockRepository.GenerateMock<IGameRepository> ();
			DependencyService.Register<IGameRepository> (m_repository);
		}

		[TearDown]
		public void CleanupTest()
		{
			m_repository.VerifyAllExpectations ();
		}
		#endregion

		#region Tests
		[Test]
		public void GetGameById_GetAllGames_AllGames()
		{
			m_repository.Expect(r => r.FindAll(null)).IgnoreArguments().Return (new Game[] { new Game { Id = 1 }, new Game { Id = 2 } });		

			var actual = GameService.GetAllGames ();
			Assert.AreEqual (2, actual.Count);
			Assert.AreEqual (1, actual [0].Id);
			Assert.AreEqual (2, actual [1].Id);
		}

		[Test]
		public void GetGameById_NonExistId_Null()
		{
			m_repository.Expect(r => r.FindAll(null)).IgnoreArguments().Return (new Game[0]);		
			Assert.IsNull (GameService.GetGameById(-1));
		}

		[Test]
		public void GetGameById_ExistId_Game()
		{
			m_repository.Expect(r => r.FindAll(null)).IgnoreArguments().Return (new Game[] { new Game { Id = 1 } });
			Assert.AreEqual(1, GameService.GetGameById(1).Id);
		}
		#endregion
	}
}