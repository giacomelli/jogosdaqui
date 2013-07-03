using System;
using KissSpecifications;
using jogosdaqui.Domain.Evaluations.Specifications;

namespace jogosdaqui.Domain.Evaluations
{
	public partial class EvaluationService
	{
		/// <summary>
		/// Executes the save specification.
		/// </summary>
		/// <param name="evaluation">Evaluation.</param>
		partial void ExecuteSaveSpecification (Evaluation evaluation)
		{
			SpecificationService.ThrowIfAnySpecificationIsNotSatisfiedBy(
				evaluation, 
				new EvaluationValidGameSpecification(),
				new EvaluationValidProsAndConsSpecification());
		}
	}
}

