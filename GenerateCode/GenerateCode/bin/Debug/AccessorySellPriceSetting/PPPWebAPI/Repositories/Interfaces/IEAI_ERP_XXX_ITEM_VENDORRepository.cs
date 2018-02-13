using System;																						
using System.Collections.Generic;																	
using System.Linq;																					
using System.Text;																					
using System.Threading.Tasks;																		
using PPPWEBAPI.Models;																				
using PPPWEBAPI.Models.ViewModels.AccessorySellPriceSetting;												
namespace PPPWEBAPI.Repositories.Interfaces															
{																									
    interface IEAI_ERP_XXX_ITEM_VENDORRepository : _IBaseRepository<EAI_ERP_XXX_ITEM_VENDORModel>						
    {																								
        bool AddEAI_ERP_XXX_ITEM_VENDOR(EAI_ERP_XXX_ITEM_VENDORModel model);							
        bool UpdateEAI_ERP_XXX_ITEM_VENDOR(EAI_ERP_XXX_ITEM_VENDORModel model);							
        bool DeleteEAI_ERP_XXX_ITEM_VENDOR(EAI_ERP_XXX_ITEM_VENDORModel model);							
    }																								
}																									
