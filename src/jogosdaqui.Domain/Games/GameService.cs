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
			SpecificationService.ThrowIfAnySpecificationIsNotSatisfiedBy (game, new GameExistsSpecification (gameKey));
		}
		#endregion
	}
}