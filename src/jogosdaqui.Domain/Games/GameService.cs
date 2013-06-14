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
		partial void ExecuteDeletionSpecification (Game game)
		{
			SpecificationService.ThrowIfAnySpecificationIsNotSatisfiedBy (game, new GameDeletionSpecification ());
		}
		#endregion
	}
}