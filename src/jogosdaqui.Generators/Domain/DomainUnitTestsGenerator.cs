﻿ 
 
 
 
 
  
  
  
  
   
   
   
   
	
using jogosdaqui.Domain.Games;
using jogosdaqui.Domain.Games.Specifications;
using jogosdaqui.Domain.Evaluations;
using jogosdaqui.Domain.Evaluations.Specifications;
using jogosdaqui.Domain.Platforms;
using jogosdaqui.Domain.Platforms.Specifications;
using jogosdaqui.Domain.Companies;
using jogosdaqui.Domain.Companies.Specifications;
using jogosdaqui.Domain.Languages;
using jogosdaqui.Domain.Languages.Specifications;
using jogosdaqui.Domain.Persons;
using jogosdaqui.Domain.Persons.Specifications;
using jogosdaqui.Domain.Articles;
using jogosdaqui.Domain.Articles.Specifications;
using jogosdaqui.Domain.Tags;
using jogosdaqui.Domain.Tags.Specifications;
   
  
#region Usings    
using System;
using NUnit.Framework;
using TestSharp; 
using jogosdaqui.Domain.UnitTests; 
using Skahal.Infrastructure.Framework.Repositories; 
using Skahal.Infrastructure.Framework.Commons;
using jogosdaqui.Infrastructure.Repositories.Testing; 
#endregion      
 
namespace jogosdaqui.Domain.UnitTests 
{ 
	public static class Stubs
	{
		#region Properties
		public static IUnitOfWork<long> UnitOfWork { get; set; }
 
		 
		#endregion 

		#region Methods
		public static void Initialize ()
		{
			DependencyService.Register<IUnitOfWork<long>> (UnitOfWork = new MemoryUnitOfWork<long>());
	
		}
		#endregion
	}
}

         
	
