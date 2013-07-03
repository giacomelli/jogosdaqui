using System;
using NUnit.Framework;
using jogosdaqui.Domain.Games;
using jogosdaqui.Domain.Evaluations;
using TestSharp;
using KissSpecifications;

namespace jogosdaqui.Domain.UnitTests
{
	public partial class EvaluationServiceTest
	{
		[Test]  
		public void SaveEvaluation_GameDoesNotExists_Exception()
		{
			var target = new EvaluationService ();
			var evaluation = new Evaluation () {
				GameKey = 1
			};

			ExceptionAssert.IsThrowing(new SpecificationNotSatisfiedException("Evaluation should have a valid Game. The game with key '1' does not exists."), () => {
				target.SaveEvaluation(evaluation);
			});
		}

		[Test]  
		public void SaveEvaluation_NoCons_Exception()
		{
			Stubs.GameRepository.Add (new Game() { Key = 1 });
			Stubs.UnitOfWork.Commit ();

			var evaluation = new Evaluation () { GameKey = 1 };
			evaluation.Pros.Add ("Pro");

			ExceptionAssert.IsThrowing(new SpecificationNotSatisfiedException("An evaluation should have at least one con."), () => {
				m_target.SaveEvaluation(evaluation);
			});
		}

		[Test]  
		public void SaveEvaluation_NoPros_Exception()
		{
			Stubs.GameRepository.Add (new Game() { Key = 1 });
			Stubs.UnitOfWork.Commit ();

			var evaluation = new Evaluation () { GameKey = 1 };
			evaluation.Cons.Add ("Con");

			ExceptionAssert.IsThrowing(new SpecificationNotSatisfiedException("An evaluation should have at least one pro."), () => {
				m_target.SaveEvaluation(evaluation);
			});
		}


		[Test]  
		public void SaveEvaluation_EvaluationDoesNotExists_Created()
		{
			Stubs.GameRepository.Add (new Game() { Key = 1 });
			Stubs.UnitOfWork.Commit ();

			var evaluation = new Evaluation () { GameKey = 1 };
			evaluation.Cons.Add ("Con");
			evaluation.Pros.Add ("Pro");

			m_target.SaveEvaluation (evaluation);

			Assert.AreEqual(5, m_target.CountAllEvaluations());
			Assert.AreEqual (5, m_target.GetEvaluationByKey (evaluation.Key).Key);
		}

		[Test]
		public void SaveEvaluation_EvaluationDoesExists_Updated()
		{
			Stubs.GameRepository.Add (new Game() { Key = 1 });
			Stubs.UnitOfWork.Commit ();

			var evaluation = new Evaluation () { 
				Key = 1, 
				GameKey = 1
			};
			evaluation.Cons.Add ("Con");
			evaluation.Pros.Add ("Pros");

			m_target.SaveEvaluation (evaluation);

			Assert.AreEqual(4, m_target.CountAllEvaluations());
			Assert.AreEqual (1, m_target.GetEvaluationByKey (evaluation.Key).Key);
		}
	}
}

