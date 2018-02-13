using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.SystemParamSetting;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IParameterCategoryRepository : _IBaseRepository<ParameterCategoryModel>						
    {																								
        SearchListViewModel QuerySearchList(SearchInfoViewModel searchInfo); 
        DetailViewModel QueryDetail(DetailRequestViewModel detailRequest);	
        bool AddParameterCategory(ParameterCategoryModel model);							
        bool UpdateParameterCategory(ParameterCategoryModel model);							
        bool DeleteParameterCategory(ParameterCategoryModel model);							
    }																								
}																									
