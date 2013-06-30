using System;
using NUnit.Framework;
using jogosdaqui.Domain.Games;
using TestSharp;
using KissSpecifications;

namespace jogosdaqui.Domain.UnitTests
{
	public partial class GameServiceTest
	{
		[Test]  
		public void SaveGame_GameDoesNotExists_Created()
		{
			var game = new Game ()  { Name = "Name 1" };

			m_target.SaveGame (game);

			Assert.AreEqual(5, m_target.CountAllGames());
			Assert.AreEqual (5, m_target.GetGameByKey (game.Key).Key);
		}

		[Test]  
		public void SaveGame_ThereIsAnotherGameWithSameName_Exception()
		{
			var company = new Game () { Name = "Name" };
			m_target.SaveGame (company);

			ExceptionAssert.IsThrowing (
				new SpecificationNotSatisfiedException ("There is another Game with the name 'Name'. Games should have unique name."), () => {
				m_target.SaveGame (new Game () { Name = "Name" });
			});
		}
	}
}

