using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.AccessorySellPriceImport;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IBatchImportMaterialErrorLogRepository : _IBaseRepository<BatchImportMaterialErrorLogModel>						
    {																								
        bool AddBatchImportMaterialErrorLog(BatchImportMaterialErrorLogModel model);							
        bool UpdateBatchImportMaterialErrorLog(BatchImportMaterialErrorLogModel model);							
        bool DeleteBatchImportMaterialErrorLog(BatchImportMaterialErrorLogModel model);							
    }																								
}																									
