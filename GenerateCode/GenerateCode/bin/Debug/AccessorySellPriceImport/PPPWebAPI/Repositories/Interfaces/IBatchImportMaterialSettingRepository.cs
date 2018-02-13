using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.AccessorySellPriceImport;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IBatchImportMaterialSettingRepository : _IBaseRepository<BatchImportMaterialSettingModel>						
    {																								
        bool AddBatchImportMaterialSetting(BatchImportMaterialSettingModel model);							
        bool UpdateBatchImportMaterialSetting(BatchImportMaterialSettingModel model);							
        bool DeleteBatchImportMaterialSetting(BatchImportMaterialSettingModel model);							
    }																								
}																									
