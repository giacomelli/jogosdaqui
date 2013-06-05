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
		#endregion

		#region Initiliaze / cleanup
		[SetUp]
		public void InitializeTest()
		{
			m_repository = new TestingGameRepository ();
			m_repository.Create (new Game());
			m_repository.Create (new Game());
			m_repository.Create (new Game());
			DependencyService.Register<IGameRepository> (m_repository);
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
			var actual = GameService.GetAllGames ();
			Assert.AreEqual (3, actual.Count);
			Assert.AreEqual (1, actual [0].Id);
			Assert.AreEqual (2, actual [1].Id);
			Assert.AreEqual (3, actual [2].Id);
		}

		[Test]
		public void GetGameById_NonExistId_Null()
		{
			Assert.IsNull (GameService.GetGameById(-1));
			Assert.IsNull (GameService.GetGameById(0));
			Assert.IsNull (GameService.GetGameById(4));
		}

		[Test]
		public void GetGameById_ExistId_Game()
		{
			Assert.AreEqual(1, GameService.GetGameById(1).Id);
			Assert.AreEqual(2, GameService.GetGameById(2).Id);
			Assert.AreEqual(3, GameService.GetGameById(3).Id);
		}

		[Test]
		public void SaveGame_Null_Exception()
		{
			ExceptionAssert.IsThrowing (new ArgumentNullException("game"), () => {
				GameService.SaveGame(null);
			});
		}

		[Test]
		public void SaveGame_NotExistingGame_Created()
		{
			var game = new Game ();
			game.Name = "Created";

			GameService.SaveGame (game);
			Assert.AreNotEqual (0, game.Id);
			var actual = GameService.GetAllGames ();
			Assert.AreEqual (4, actual.Count);

			Assert.AreEqual ("Created", GameService.GetGameById(game.Id).Name);
		}

		[Test]
		public void SaveGame_ExistingGame_Updated()
		{
			var game = new Game ();
			game.Id = 2;
			game.Name = "Updated";

			GameService.SaveGame (game);
			var actual = GameService.GetAllGames ();
			Assert.AreEqual (3, actual.Count);

			var updated = GameService.GetGameById (2);
			Assert.AreEqual ("Updated", updated.Name);
		}

		[Test]
		public void DeleteGame_NotExistingGame_Exception()
		{
			ExceptionAssert.IsThrowing (new SpecificationNotSatisfiedException("The game should exists to be deleted."), () => {
				GameService.DeleteGame(4);
			});
		}

		[Test]
		public void DeleteGame_ExistingGame_Deleted()
		{
			GameService.DeleteGame (1);
			Assert.IsNull (GameService.GetGameById(1));
			Assert.AreEqual (2, GameService.CountAllGames ());

			GameService.DeleteGame (2);
			Assert.IsNull (GameService.GetGameById(2));
			Assert.AreEqual (1, GameService.CountAllGames ());

			GameService.DeleteGame (3);
			Assert.IsNull (GameService.GetGameById(3));
			Assert.AreEqual (0, GameService.CountAllGames ());
		}
		#endregion
	}
}