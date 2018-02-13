using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.ActorSetting;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IActorFunctionRepository : _IBaseRepository<ActorFunctionModel>						
    {																								
        bool AddActorFunction(ActorFunctionModel model);							
        bool UpdateActorFunction(ActorFunctionModel model);							
        bool DeleteActorFunction(ActorFunctionModel model);							
    }																								
}																									
