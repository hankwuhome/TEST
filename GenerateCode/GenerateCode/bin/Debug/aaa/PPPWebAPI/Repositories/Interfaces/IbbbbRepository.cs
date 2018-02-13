using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.aaa;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IbbbbRepository : _IBaseRepository<bbbbModel>						
    {																								
        SearchListViewModel QuerySearchList(SearchInfoViewModel searchInfo); 
        DetailViewModel QueryDetail(DetailRequestViewModel detailRequest);	
        bool Addbbbb(bbbbModel model);							
        bool Updatebbbb(bbbbModel model);							
        bool Deletebbbb(bbbbModel model);							
    }																								
}																									
