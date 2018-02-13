using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.AccessorySellPriceSetting;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IEAI_ERP_XXX_ITEM_CATEGORYRepository : _IBaseRepository<EAI_ERP_XXX_ITEM_CATEGORYModel>						
    {																								
        bool AddEAI_ERP_XXX_ITEM_CATEGORY(EAI_ERP_XXX_ITEM_CATEGORYModel model);							
        bool UpdateEAI_ERP_XXX_ITEM_CATEGORY(EAI_ERP_XXX_ITEM_CATEGORYModel model);							
        bool DeleteEAI_ERP_XXX_ITEM_CATEGORY(EAI_ERP_XXX_ITEM_CATEGORYModel model);							
    }																								
}																									
