using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.AccessorySellPriceSetting;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IMaterialVerifyFormRepository : _IBaseRepository<MaterialVerifyFormModel>						
    {																								
        SearchListViewModel QuerySearchList(SearchInfoViewModel searchInfo); 
        DetailViewModel QueryDetail(DetailRequestViewModel detailRequest);	
        bool AddMaterialVerifyForm(MaterialVerifyFormModel model);							
        bool UpdateMaterialVerifyForm(MaterialVerifyFormModel model);							
        bool DeleteMaterialVerifyForm(MaterialVerifyFormModel model);							
    }																								
}																									
