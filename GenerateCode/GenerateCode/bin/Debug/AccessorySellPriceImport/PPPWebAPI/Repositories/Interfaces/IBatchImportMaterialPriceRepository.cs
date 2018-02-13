using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.AccessorySellPriceImport;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IBatchImportMaterialPriceRepository : _IBaseRepository<BatchImportMaterialPriceModel>						
    {																								
        bool AddBatchImportMaterialPrice(BatchImportMaterialPriceModel model);							
        bool UpdateBatchImportMaterialPrice(BatchImportMaterialPriceModel model);							
        bool DeleteBatchImportMaterialPrice(BatchImportMaterialPriceModel model);							
    }																								
}																									
