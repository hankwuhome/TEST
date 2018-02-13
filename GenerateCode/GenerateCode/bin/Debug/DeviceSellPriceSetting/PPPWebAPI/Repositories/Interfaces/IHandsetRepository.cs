using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.DeviceSellPriceSetting;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IHandsetRepository : _IBaseRepository<HandsetModel>						
    {																								
        SearchListViewModel QuerySearchList(SearchInfoViewModel searchInfo); 
        DetailViewModel QueryDetail(DetailRequestViewModel detailRequest);	
        bool AddHandset(HandsetModel model);							
        bool UpdateHandset(HandsetModel model);							
        bool DeleteHandset(HandsetModel model);							
    }																								
}																									
