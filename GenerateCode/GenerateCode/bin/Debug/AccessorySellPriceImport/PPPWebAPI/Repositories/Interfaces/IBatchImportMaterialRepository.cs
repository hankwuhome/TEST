using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.AccessorySellPriceImport;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IBatchImportMaterialRepository : _IBaseRepository<BatchImportMaterialModel>						
    {																								
        SearchListViewModel QuerySearchList(SearchInfoViewModel searchInfo); 
        DetailViewModel QueryDetail(DetailRequestViewModel detailRequest);	
        bool AddBatchImportMaterial(BatchImportMaterialModel model);							
        bool UpdateBatchImportMaterial(BatchImportMaterialModel model);							
        bool DeleteBatchImportMaterial(BatchImportMaterialModel model);							
    }																								
}																									
