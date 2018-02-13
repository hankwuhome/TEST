using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.ActorSetting;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IActorRepository : _IBaseRepository<ActorModel>						
    {																								
        SearchListViewModel QuerySearchList(SearchInfoViewModel searchInfo); 
        DetailViewModel QueryDetail(DetailRequestViewModel detailRequest);	
        bool AddActor(ActorModel model);							
        bool UpdateActor(ActorModel model);							
        bool DeleteActor(ActorModel model);							
    }																								
}																									
