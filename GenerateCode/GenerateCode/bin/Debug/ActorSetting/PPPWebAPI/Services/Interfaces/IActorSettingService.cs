using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models.ViewModels.ActorSetting;												
namespace PPPWEBAPI.Services.Interfaces															
{																									
    interface IActorSettingService 						
    {																								
        SearchInfoInitViewModel QuerySearchInfoInit(); 
        SearchListViewModel QuerySearchList(SearchInfoViewModel searchInfo); 
        DetailViewModel QueryDetail(DetailRequestViewModel detailRequest);	
        DetailOptionViewModel QueryDetailOption(); 
        bool AddDetail(DetailViewModel detail);	
        bool EditDetail(DetailViewModel detail);	
        bool DeleteDetail(DetailViewModel detail);	
    }																								
}																									
