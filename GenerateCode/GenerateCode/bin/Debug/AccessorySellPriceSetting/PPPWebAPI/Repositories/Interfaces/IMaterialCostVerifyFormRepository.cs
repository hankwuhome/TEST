using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.AccessorySellPriceSetting;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IMaterialCostVerifyFormRepository : _IBaseRepository<MaterialCostVerifyFormModel>						
    {																								
        bool AddMaterialCostVerifyForm(MaterialCostVerifyFormModel model);							
        bool UpdateMaterialCostVerifyForm(MaterialCostVerifyFormModel model);							
        bool DeleteMaterialCostVerifyForm(MaterialCostVerifyFormModel model);							
    }																								
}																									
