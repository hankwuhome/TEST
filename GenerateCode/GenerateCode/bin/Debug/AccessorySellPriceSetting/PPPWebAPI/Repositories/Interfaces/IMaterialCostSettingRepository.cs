using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.AccessorySellPriceSetting;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IMaterialCostSettingRepository : _IBaseRepository<MaterialCostSettingModel>						
    {																								
        bool AddMaterialCostSetting(MaterialCostSettingModel model);							
        bool UpdateMaterialCostSetting(MaterialCostSettingModel model);							
        bool DeleteMaterialCostSetting(MaterialCostSettingModel model);							
    }																								
}																									
