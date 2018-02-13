using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.AccessorySellPriceImport;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IBatchImportMaterialCostSettingRepository : _IBaseRepository<BatchImportMaterialCostSettingModel>						
    {																								
        bool AddBatchImportMaterialCostSetting(BatchImportMaterialCostSettingModel model);							
        bool UpdateBatchImportMaterialCostSetting(BatchImportMaterialCostSettingModel model);							
        bool DeleteBatchImportMaterialCostSetting(BatchImportMaterialCostSettingModel model);							
    }																								
}																									
