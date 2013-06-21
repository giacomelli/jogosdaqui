using System;
using System.Linq;
using HelperSharp;
using Skahal.Infrastructure.Framework.Domain;
using jogosdaqui.Domain.Games;

namespace jogosdaqui.Domain
{
	/// <summary>
	/// A domain service facade.
	/// </summary>
	public static class ServiceFacade
	{
		/// <summary>
		/// Creates the service for the specify entity.
		/// </summary>
		/// <returns>The service.</returns>
		/// <param name="entity">Entity.</param>
		internal static object CreateService(IEntity<long> entity)
		{
			ExceptionHelper.ThrowIfNull("entity", entity);

			var entityType = entity.GetType ();
			var serviceName = "{0}.{1}Service".With (entityType.Namespace, entityType.Name);
			var serviceType = Type.GetType(serviceName);

			if (serviceType == null) {
				throw new InvalidOperationException("Could not found a service ({0}) for the entity '{1}'.".With (serviceName, entityType.Name));
			}

			return Activator.CreateInstance(serviceType);
		}

		/// <summary>
		/// Creates the entity.
		/// </summary>
		/// <returns>The entity.</returns>
		/// <param name="entityName">Entity name.</param>
		internal static IEntity<long> CreateTransientEntity(string entityName)
		{
			if(String.IsNullOrWhiteSpace(entityName))
			{
				throw new ArgumentNullException ("entityName");
			}

			var assembly = typeof(ServiceFacade).Assembly;
			var entityType = assembly.GetTypes ().FirstOrDefault (t => t.Name.Equals(entityName, StringComparison.OrdinalIgnoreCase));

			if (entityType == null) {
				throw new ArgumentException ("There is no entity with the name '{0}'.".With(entityName));
			}

			return (IEntity<long>)assembly.CreateInstance (entityType.FullName);
	
		}

		/// <summary>
		/// Gets the entity by key.
		/// </summary>
		/// <returns>The entity by key.</returns>
		/// <param name="entityName">Entity name.</param>
		/// <param name="entityKey">Entity key.</param>
		public static IEntity<long> GetEntityByKey(string entityName, long entityKey)
		{
			var transientEntity = CreateTransientEntity (entityName);
			var service = CreateService (transientEntity);
			var serviceType = service.GetType ();
			var getByKeyMethodName = "Get{0}ByKey".With (entityName);

			var entity = serviceType.GetMethod (getByKeyMethodName).Invoke (service, new object[] { entityKey });

			return (IEntity<long>) entity;
		}
	}
}

