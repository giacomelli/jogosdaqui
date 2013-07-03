using System;
using System.Collections.Generic;
using System.Linq;
using HelperSharp;
using KissSpecifications;
using Skahal.Infrastructure.Framework.Commons;
using Skahal.Infrastructure.Framework.Repositories;
using jogosdaqui.Domain.Games.Specifications;

namespace jogosdaqui.Domain.Games
{
	public partial class GameService
	{	
		#region Methods
		/// <summary>
		/// Executes the delete specification.
		/// </summary>
		/// <param name="gameKey">Game key.</param>
		/// <param name="game">Game.</param>
		partial void ExecuteDeleteSpecification(long gameKey, Game game)
		{
			SpecificationService.ThrowIfAnySpecificationIsNotSatisfiedBy (game, new GameExistsSpecification ());
		}

		/// <summary>
		/// Executes the save specification.
		/// </summary>
		/// <param name="game">Game.</param>
		partial void ExecuteSaveSpecification (Game game)
		{
			SpecificationService.ThrowIfAnySpecificationIsNotSatisfiedBy (
				game,                                             
				new GameUniqueNameSpecification (),
				new GameValidPlatformsSpecification());
		}
		#endregion
	}
}