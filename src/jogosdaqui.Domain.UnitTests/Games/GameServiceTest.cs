using System;
using NUnit.Framework;
using jogosdaqui.Domain.Games;
using TestSharp;
using KissSpecifications;
using jogosdaqui.Domain.Platforms;

namespace jogosdaqui.Domain.UnitTests
{
	public partial class GameServiceTest
	{
		#region Tests
		[Test]  
		public void SaveGame_ThereIsAnotherGameWithSameName_Exception()
		{
			var company = CreateValidGame (0);
			m_target.SaveGame (company);

			ExceptionAssert.IsThrowing (
				new SpecificationNotSatisfiedException ("There is another Game with the name 'Name'. Games should have unique name."), () => {
				m_target.SaveGame (new Game () { Name = "Name" });
			});
		}

		[Test]
		public void SaveGame_WithoutPlatform_Exception()
		{
			ExceptionAssert.IsThrowing (
				new SpecificationNotSatisfiedException ("A game should have at least one platform."), () => {
				m_target.SaveGame (new Game () { Name = "Name" });
			});
		}

		[Test]
		public void SaveGame_WithInvalidPlatform_Exception()
		{
			var game = new Game () { Name = "Name" };
			game.PlatformKeys.Add(1);

			ExceptionAssert.IsThrowing (
				new SpecificationNotSatisfiedException ("Game should have a valid platform. The platform with key '1' does not exists."), () => {
				m_target.SaveGame (game);
			});
		}

		[Test]
		public void SaveGame_WithDuplicatedPlatform_Exception()
		{
			var game = new Game () { Name = "Name" };
			game.PlatformKeys.Add(1);
			game.PlatformKeys.Add(1);
			game.PlatformKeys.Add (2);
			game.PlatformKeys.Add(3);
			game.PlatformKeys.Add(3);

			ExceptionAssert.IsThrowing (
				new SpecificationNotSatisfiedException ("Game can't have duplicate platforms. The platform with key '1' appears more than one time."), () => {
				m_target.SaveGame (game);
			});
		}

		[Test]
		public void SaveGame_WithoutDeveloperCompany_Exception()
		{
			ExceptionAssert.IsThrowing (
				new SpecificationNotSatisfiedException ("A game should have at least one developer company."), () => {
				m_target.SaveGame (new Game () { Name = "Name" });
			});
		}

		[Test]
		public void SaveGame_WithInvalidCompany_Exception()
		{
			var game = new Game () { Name = "Name" };
			game.DeveloperCompanyKeys.Add(1);

			ExceptionAssert.IsThrowing (
				new SpecificationNotSatisfiedException ("Game should have a valid developer company. The developer company with key '1' does not exists."), () => {
				m_target.SaveGame (game);
			});
		}

		[Test]  
		public void SaveGame_GameDoesNotExists_Created()
		{
			var game = CreateValidGame (0);

			m_target.SaveGame (game);

			Assert.AreEqual(5, m_target.CountAllGames());
			Assert.AreEqual (5, m_target.GetGameByKey (game.Key).Key);
		}

		[Test]
		public void SaveGame_GameDoesExists_Updated()
		{
			var game = CreateValidGame (1);

			m_target.SaveGame (game);

			Assert.AreEqual(4, m_target.CountAllGames());
			Assert.AreEqual (1, m_target.GetGameByKey (game.Key).Key);
		}
		#endregion

		#region Helpers
		private Game CreateValidGame(long key)
		{
			Stubs.PlatformRepository.Add (new Platform());
			Stubs.UnitOfWork.Commit();

			var game = new Game () { 
				Key = key,
				Name = "Name"
			};

			game.PlatformKeys.Add(1);

			return game;
		}
		#endregion
	}
}

