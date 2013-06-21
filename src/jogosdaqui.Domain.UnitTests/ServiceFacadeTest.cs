using System;
using HelperSharp;
using NUnit.Framework;
using Rhino.Mocks;
using Skahal.Infrastructure.Framework.Domain;
using TestSharp;
using jogosdaqui.Domain.Games;
using jogosdaqui.Domain.Tags;

namespace jogosdaqui.Domain.UnitTests
{
	[TestFixture()]
	public class ServiceFacadeTest
	{
		#region Initialize
		[SetUp]
		public void InitializeTest()
		{
			Stubs.Initialize ();
		}
		#endregion

		#region Tests
		[Test()]
		public void CreateService_Null_Exception ()
		{
			ExceptionAssert.IsThrowing (new ArgumentNullException("entity"), () => {
				ServiceFacade.CreateService(null);
			});
		}

		[Test()]
		public void CreateService_ServiceNotFound_Exception ()
		{
			var entity = MockRepository.GenerateMock<IEntity<long>> ();
			var msg = "Could not found a service ({0}.{1}Service) for the entity '{1}'.".With (entity.GetType().Namespace, entity.GetType ().Name);

			ExceptionAssert.IsThrowing (new InvalidOperationException(msg), () => {
				ServiceFacade.CreateService(entity);
			});
		}

		[Test()]
		public void CreateService_ServiceFound_ServiceInstance ()
		{
			var gameService = ServiceFacade.CreateService (new Game());
			Assert.AreEqual (typeof(GameService), gameService.GetType());

			var tagService = ServiceFacade.CreateService (new Tag());
			Assert.AreEqual (typeof(TagService), tagService.GetType());
		}

		[Test]
		public void GetEntityByKey_NullEntityNameAndKey_Exception ()
		{
			ExceptionAssert.IsThrowing(new ArgumentNullException("entityName"), () => {
				ServiceFacade.GetEntityByKey(null, 1);
			});

			ExceptionAssert.IsThrowing(new ArgumentNullException("entityName"), () => {
				ServiceFacade.GetEntityByKey("", 1);
			});
		}

		[Test]
		public void GetEntityByKey_DoesNotExistsEntityWithName_Exception ()
		{
			ExceptionAssert.IsThrowing(new ArgumentException ("There is no entity with the name 'Jogo'."), () => {
				ServiceFacade.GetEntityByKey("Jogo", 1);
			});
		}

		[Test]
		public void GetEntityByKey_EntityNameAndKey_AppliedTags ()
		{
			Stubs.GameRepository.Add (new Game(1));
			Stubs.TagRepository.Add (new Tag(1));
			Stubs.UnitOfWork.Commit ();

			var actual = ServiceFacade.GetEntityByKey ("Game", 1);
			Assert.AreEqual (1, actual.Key);

			actual = ServiceFacade.GetEntityByKey ("Tag", 1);
			Assert.AreEqual (1, actual.Key);

			actual = ServiceFacade.GetEntityByKey ("Tag", 2);
			Assert.IsNull (actual);

			actual = ServiceFacade.GetEntityByKey ("AppliedTag", 1);
			Assert.IsNull (actual);
		}
		#endregion
	}
}