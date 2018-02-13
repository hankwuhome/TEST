using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.SystemParamSetting;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IParameterItemRepository : _IBaseRepository<ParameterItemModel>						
    {																								
        bool AddParameterItem(ParameterItemModel model);							
        bool UpdateParameterItem(ParameterItemModel model);							
        bool DeleteParameterItem(ParameterItemModel model);							
    }																								
}																									
