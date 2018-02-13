using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.DeviceSellPriceHistory;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IHandSetRepository : _IBaseRepository<HandSetModel>						
    {																								
        SearchListViewModel QuerySearchList(SearchInfoViewModel searchInfo); 
        DetailViewModel QueryDetail(DetailRequestViewModel detailRequest);	
        bool AddHandSet(HandSetModel model);							
        bool UpdateHandSet(HandSetModel model);							
        bool DeleteHandSet(HandSetModel model);							
    }																								
}																									
