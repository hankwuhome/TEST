using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.HandsetSellPriceHistory;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IHandsetVerifyFormRepository : _IBaseRepository<HandsetVerifyFormModel>						
    {																								
        SearchListViewModel QuerySearchList(SearchInfoViewModel searchInfo); 
        DetailViewModel QueryDetail(DetailRequestViewModel detailRequest);	
        bool AddHandsetVerifyForm(HandsetVerifyFormModel model);							
        bool UpdateHandsetVerifyForm(HandsetVerifyFormModel model);							
        bool DeleteHandsetVerifyForm(HandsetVerifyFormModel model);							
    }																								
}																									
