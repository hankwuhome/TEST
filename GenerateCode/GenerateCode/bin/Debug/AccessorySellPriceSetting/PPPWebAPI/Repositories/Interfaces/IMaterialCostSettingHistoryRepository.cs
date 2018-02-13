using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.AccessorySellPriceSetting;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IMaterialCostSettingHistoryRepository : _IBaseRepository<MaterialCostSettingHistoryModel>						
    {																								
        bool AddMaterialCostSettingHistory(MaterialCostSettingHistoryModel model);							
        bool UpdateMaterialCostSettingHistory(MaterialCostSettingHistoryModel model);							
        bool DeleteMaterialCostSettingHistory(MaterialCostSettingHistoryModel model);							
    }																								
}																									
