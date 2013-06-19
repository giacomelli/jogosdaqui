using NUnit.Framework;
using System;
using jogosdaqui.Domain.Games;
using Rhino.Mocks;
using Skahal.Infrastructure.Framework.Commons;
using System.Linq;
using Skahal.Infrastructure.Framework.Domain;
using Skahal.Infrastructure.Framework.Repositories;
using jogosdaqui.Infrastructure.Repositories.Testing;
using TestSharp;
using KissSpecifications;

namespace jogosdaqui.Domain.UnitTests
{
	[TestFixture()]
	public class GameServiceTest
	{
		#region Fields
		private IGameRepository m_repository;
		private IUnitOfWork<long> m_unitOfWork;
		private GameService m_service;
		#endregion

		#region Initiliaze / cleanup
		[SetUp]
		public void InitializeTest()
		{
			m_unitOfWork = new MemoryUnitOfWork<long> ();
			m_repository = new TestingGameRepository ();
			m_repository.SetUnitOfWork(m_unitOfWork);
			m_repository.Add (new Game());
			m_repository.Add (new Game());
			m_repository.Add (new Game());
			m_unitOfWork.Commit ();

			m_service = new GameService (m_repository, m_unitOfWork);
		}

		[TearDown]
		public void CleanupTest()
		{
		}
		#endregion

		#region Tests
		[Test]
		public void GetGameById_GetAllGames_AllGames()
		{
			var actual = m_service.GetAllGames ();
			Assert.AreEqual (3, actual.Count);
			Assert.AreEqual (1, actual [0].Key);
			Assert.AreEqual (2, actual [1].Key);
			Assert.AreEqual (3, actual [2].Key);
		}

		[Test]
		public void GetGameById_NonExistId_Null()
		{
			Assert.IsNull (m_service.GetGameByKey(-1));
			Assert.IsNull (m_service.GetGameByKey(0));
			Assert.IsNull (m_service.GetGameByKey(4));
		}

		[Test]
		public void GetGameById_ExistId_Game()
		{
			Assert.AreEqual(1, m_service.GetGameByKey(1).Key);
			Assert.AreEqual(2, m_service.GetGameByKey(2).Key);
			Assert.AreEqual(3, m_service.GetGameByKey(3).Key);
		}

		[Test]
		public void SaveGame_Null_Exception()
		{
			ExceptionAssert.IsThrowing (new ArgumentNullException("game"), () => {
				m_service.SaveGame(null);
			});
		}

		[Test]
		public void SaveGame_NotExistingGame_Created()
		{
			var game = new Game ();
			game.Name = "Created";

			m_service.SaveGame (game);
			Assert.AreNotEqual (0L, game.Key);
			var actual = m_service.GetAllGames ();
			Assert.AreEqual (4, actual.Count);

			Assert.AreEqual ("Created", m_service.GetGameByKey(game.Key).Name);
		}

		[Test]
		public void SaveGame_ExistingGame_Updated()
		{
			var game = new Game ();
			game.Key = 2;
			game.Name = "Updated";

			m_service.SaveGame (game);
			var actual = m_service.GetAllGames ();
			Assert.AreEqual (3, actual.Count);

			var updated = m_service.GetGameByKey (2);
			Assert.AreEqual ("Updated", updated.Name);
		}

		[Test]
		public void DeleteGame_ExistingGame_Deleted()
		{
			m_service.DeleteGame (1);
			Assert.IsNull (m_service.GetGameByKey(1));
			Assert.AreEqual (2, m_service.CountAllGames ());

			m_service.DeleteGame (2);
			Assert.IsNull (m_service.GetGameByKey(2));
			Assert.AreEqual (1, m_service.CountAllGames ());

			m_service.DeleteGame (3);
			Assert.IsNull (m_service.GetGameByKey(3));
			Assert.AreEqual (0, m_service.CountAllGames ());
		}
		#endregion
	}
}