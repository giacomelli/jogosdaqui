using System;
using NUnit.Framework;
using jogosdaqui.Domain.Articles;
using TestSharp;
using KissSpecifications;
using jogosdaqui.Domain.Games;

namespace jogosdaqui.Domain.UnitTests
{
	[TestFixture()]
	public partial class EventServiceTest
	{
		#region Tests
		[Test()]
		public void GetEventsByGameKey_GameDoesNotExists_Exception ()
		{
			var target = new EventService ();

			ExceptionAssert.IsThrowing(new SpecificationNotSatisfiedException("Game can't be null."), () => {
				target.GetEventsByGameKey(0);
			});
		}

		[Test()]
		public void GetEventsByGameKey_Key_ArticlesOfManyTypes ()
		{
			var game = new Game (1);
			Stubs.GameRepository.Add (game);

			game = new Game (2);
			Stubs.GameRepository.Add (game);

			var @event = new Event (11) { Title = "Evento 11" };
			@event.GamesRelated.Add (game);
			Stubs.EventRepository.Add (@event);

			@event = new Event (22) { Title = "Evento 22" };
			Stubs.EventRepository.Add (@event);

			@event = new Event (33) { Title = "Evento 33" };
			@event.GamesRelated.Add (game);
			Stubs.EventRepository.Add (@event);

			Stubs.UnitOfWork.Commit ();

			var target = new EventService ();
			var actual = target.GetEventsByGameKey (game.Key);

			Assert.AreEqual (2, actual.Count);
			Assert.AreEqual ("Evento 11", actual [0].Title);
			Assert.AreEqual ("Evento 33", actual [1].Title);
		}
		#endregion
	}
}

